using System.Net;
using System.Text;
using BinancePayConnector.Core.Clients.Extensions;
using BinancePayConnector.Core.Clients.Exceptions;
using BinancePayConnector.Core.Clients.JsonSerialization.Resolvers;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Config.Options;
using BinancePayConnector.Core.Models.C2B.RestApi.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BinancePayConnector.Core.Clients;

public class BinancePayClient : IBinancePayClient
{
    private readonly string _apiKey;
    private readonly string _apiSecret;

    public BinancePayClient(
        string apiKey,
        string apiSecret)
    {
        _apiKey = apiKey;
        _apiSecret = apiSecret;
    }

    public BinancePayClient(IOptions<BinancePayConfig> config)
    {
        _apiKey = config.Value.ApiKey;
        _apiSecret = config.Value.ApiSecret;
    }

    public string ApiBaseUri => BinancePayEndpoints.ApiBaseUrl + '/';

    public async Task<BinancePayResult<TResponse>> SendBinanceAsync<TResponse>(
        HttpMethod method,
        string path,
        CancellationToken ct = default)
        => await SendBinanceAsync<TResponse, object>(method, path, ct: ct);

    public async Task<BinancePayResult<TResponse>> SendBinanceAsync<TResponse, TContent>(
        HttpMethod method,
        string path,
        TContent? content = default,
        CancellationToken ct = default)
    {
        var requestJson = GetJsonOrNullByObject(content);
        var requestHeaders = BuildRequestHeaders(requestJson);
        var requestMessage = BuildRequestMessage(path, method, requestJson, requestHeaders);

        // TODO: Think about optimize http client with some settings.
        using var client = new HttpClient();

        var response = await client.SendAsync(requestMessage, ct);
        var responseData = await response.Content.ReadAsStringAsync(ct);

        if (!response.IsSuccessStatusCode)
        {
            return DeserializeBadResponse<TResponse>(responseData, response.StatusCode);
        }

        var result = DeserializeJsonToObject<WebApiResult<TResponse>>(responseData);
        return result.AsBinancePayResult();
    }

    private static string? GetJsonOrNullByObject<TContent>(TContent? content)
    {
        // Because Newtonsoft.NET returns "null" if content null
        if (content == null)
        {
            return null;
        }

        return JsonConvert.SerializeObject(content, new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        });
    }

    private Dictionary<string, string> BuildRequestHeaders(string? body)
        => BinanceHttpHeadersBuilder.Init()
            .WithTimestamp()
            .WithNonce()
            .WithCertificate(_apiKey)
            .WithSignature(body, _apiSecret)
            .Build();

    private static HttpRequestMessage BuildRequestMessage(
        string path,
        HttpMethod method,
        string? json = null,
        Dictionary<string, string>? headers = null)
    {
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = GetUri(path),
            Method = method,
            Content = GetHttpContentOrNull(json)
        };

        if (headers == null)
        {
            return requestMessage;
        }

        foreach (var (key, value) in headers)
        {
            requestMessage.Headers.Add(key, value);
        }

        return requestMessage;
    }

    private static Uri GetUri(string path) => new(BinancePayEndpoints.ApiBaseUrl + path);

    private static StringContent? GetHttpContentOrNull(string? json)
    {
        if (json == null)
        {
            return null;
        }

        const string httpMediaType = "application/json";
        return new StringContent(json, Encoding.UTF8, httpMediaType);
    }

    private static BinancePayResult<TResponse> DeserializeBadResponse<TResponse>(
        string responseData,
        HttpStatusCode statusCode)
    {
        try
        {
            var result = DeserializeJsonToObject<WebApiResult<object>>(responseData);
            return result.AsBinancePayResult<TResponse>(statusCode);
        }
        catch(BinancePayDeserializeException e)
        {
            return e.AsBinancePayResult<TResponse>(statusCode);
        }
    }

    private static T DeserializeJsonToObject<T>(string json)
    {
        try
        {
            var deserializeObject = JsonConvert.DeserializeObject<T>(json);
            return deserializeObject ?? throw new BinancePayDeserializeException(json);
        }
        catch
        {
            throw new BinancePayDeserializeException(json);
        }
    }
}

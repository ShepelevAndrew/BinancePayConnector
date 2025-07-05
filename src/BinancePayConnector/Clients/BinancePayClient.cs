using System.Net.Http.Headers;
using System.Text;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Clients.Extensions;
using BinancePayConnector.Clients.JsonSerialization.Resolvers;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Config.Options;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Common;
using BinancePayConnector.Models.C2B.RestApi.Common.Enums;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BinancePayConnector.Clients;

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

        if (!response.IsSuccessStatusCode)
        {
            return await DeserializeBadResponse<TResponse>(response);
        }

        var responseData = await response.Content.ReadAsStringAsync(ct);
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
        string? json = default,
        Dictionary<string, string>? headers = default)
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

        var httpType = new MediaTypeHeaderValue("application/json");
        return new StringContent(json, Encoding.UTF8, httpType);
    }

    private static async Task<BinancePayResult<TResponse>> DeserializeBadResponse<TResponse>(HttpResponseMessage response)
    {
        var responseData = await response.Content.ReadAsStringAsync();
        try
        {
            var result = DeserializeJsonToObject<WebApiResult<object>>(responseData);

            return new BinancePayResult<TResponse>(
                errorMessage: result.ErrorMessage,
                statusCode: response.StatusCode,
                binanceStatusCode: result.Status,
                requestStatus: RequestStatus.Fail,
                body: default);
        }
        catch(BinancePayDeserializeException e)
        {
            return new BinancePayResult<TResponse>(
                errorMessage: e.Message,
                statusCode: response.StatusCode,
                binanceStatusCode: BinanceStatusCodeConst.RequestError,
                requestStatus: RequestStatus.Fail,
                body: default);
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

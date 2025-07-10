using System.Net;
using System.Text;
using BinancePayConnector.Core.Clients.JsonSerialization.Resolvers;
using BinancePayConnector.Core.Models.C2B.Webhook.Common;
using Newtonsoft.Json;

namespace BinancePayConnector.Core.Clients.WebHookListener.Helpers;

public static class HttpListenerHelper
{
    public static async Task<WebHookRequest> ReadWebHookRequest(
        this HttpListenerContext context,
        CancellationToken ct)
    {
        string requestBody;
        using (var reader = new StreamReader(context.Request.InputStream, Encoding.UTF8))
        {
            requestBody = await reader.ReadToEndAsync();
        }

        return JsonConvert.DeserializeObject<WebHookRequest>(requestBody)
               ?? throw new ArgumentException("Invalid request body.");
    }

    public static async Task SendOkResponse(
        this HttpListenerContext context,
        string status,
        CancellationToken ct)
    {
        var responseJson = JsonConvert.SerializeObject(
            value: new WebHookResponse(status),
            settings: new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            });

        var responseBytes = Encoding.UTF8.GetBytes(responseJson);

        context.Response.StatusCode = (int)HttpStatusCode.OK;
        context.Response.ContentType = "application/json";
        context.Response.ContentLength64 = responseBytes.Length;

        await context.Response.OutputStream.WriteAsync(responseBytes, ct);
        context.Response.Close();
    }

    public static void SendNotFoundResponse(
        this HttpListenerContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        context.Response.ContentType = "application/json";
        context.Response.Close();
    }
}
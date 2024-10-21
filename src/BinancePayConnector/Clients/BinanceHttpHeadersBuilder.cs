using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace BinancePayConnector.Clients;

public interface IBinanceHttpHeadersProcessing
{
    IBinanceHttpHeadersProcessing WithTimestamp();

    IBinanceHttpHeadersProcessing WithNonce();

    IBinanceHttpHeadersEnding WithCertificate(string apiKey);
}

public interface IBinanceHttpHeadersEnding
{
    IBinanceHttpHeadersBuilder WithSignature(
        string? body,
        string apiSecret);
}

public interface IBinanceHttpHeadersBuilder
{
    Dictionary<string, string> Build();
}

public class BinanceHttpHeadersBuilder
    : IBinanceHttpHeadersBuilder, IBinanceHttpHeadersProcessing, IBinanceHttpHeadersEnding
{
    private readonly Dictionary<string, string> _httpHeaders;

    private long _timeStamp;
    private string? _binanceNonce;
    private string? _binanceApiKey;
    private string? _binanceSignature;

    private const string BinanceTimeStamp = "BinancePay-Timestamp";
    private const string BinanceNonce = "BinancePay-Nonce";
    private const string BinanceCertificate = "BinancePay-Certificate-SN";
    private const string BinanceSignature = "BinancePay-Signature";

    private const string CharsForNonce = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private BinanceHttpHeadersBuilder()
        => _httpHeaders = [];

    public static IBinanceHttpHeadersProcessing Init()
        => new BinanceHttpHeadersBuilder();

    public IBinanceHttpHeadersProcessing WithTimestamp()
    {
        _timeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        _httpHeaders.Add(BinanceTimeStamp, _timeStamp.ToString(CultureInfo.InvariantCulture));
        return this;
    }

    public IBinanceHttpHeadersProcessing WithNonce()
    {
        const int nonceLength = 32;
        _binanceNonce = GetBinancePayNonce(nonceLength);

        _httpHeaders.Add(BinanceNonce, _binanceNonce);
        return this;
    }

    public IBinanceHttpHeadersEnding WithCertificate(
        string apiKey)
    {
        _binanceApiKey = apiKey;

        _httpHeaders.Add(BinanceCertificate, _binanceApiKey);
        return this;
    }

    public IBinanceHttpHeadersBuilder WithSignature(
        string? body,
        string apiSecret)
    {
        var payload = $"{_timeStamp}\n{_binanceNonce}\n{body}\n";
        _binanceSignature = GenerateSignature(payload, apiSecret);

        _httpHeaders.Add(BinanceSignature, _binanceSignature);
        return this;
    }

    public Dictionary<string, string> Build() => _httpHeaders;

    private static string GetBinancePayNonce(int length)
    {
        var nonce = new StringBuilder(length);
        var random = new Random();

        for (var i = 0; i < length; i++)
        {
            var randomIndex = random.Next(CharsForNonce.Length);
            nonce.Append(CharsForNonce[randomIndex]);
        }

        return nonce.ToString();
    }

    private static string GenerateSignature(
        string payload,
        string secretKey)
    {
        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(secretKey));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
        return BitConverter.ToString(hash).Replace("-", "").ToUpper(CultureInfo.InvariantCulture);
    }
}

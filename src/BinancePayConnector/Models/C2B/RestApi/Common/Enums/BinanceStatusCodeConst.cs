namespace BinancePayConnector.Models.C2B.RestApi.Common.Enums;

/// <summary>
/// It is Binance Pay API status codes, see in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-common#common-business-errors"/>
/// </summary>
public static class BinanceStatusCodeConst
{
    public const string RequestError = "1"; // Not binance status code, only for mark request error
    public const string Success = "000000";
    public const string UnknownError = "400000";
    public const string InvalidRequest = "400001";
    public const string InvalidSignature = "400002";
    public const string InvalidTimeStamp = "400003";
    public const string InvalidApiKeyOrIp = "400004";
    public const string BadApiKeyFmt = "400005";
    public const string BadHttpMethod = "400006";
    public const string MediaTypeNotSupported = "400007";
    public const string InvalidRequestBody = "400008";
    public const string MandatoryParamEmptyOrMalformed = "400100";
    public const string InvalidParamWrongLength = "400101";
    public const string InvalidParamWrongValue = "400102";
    public const string InvalidParamIllegalChar = "400103";
    public const string InvalidRequestTooLarge = "400104";
    public const string InvalidMerchantTradeNo = "400201";
    public const string InvalidAccountStatus = "400203";
    public const string SubMerchantInvalid = "400206";

    public static readonly Dictionary<string, int> MapToWeb = new()
    {
        { Success, 200 },
        { RequestError, 500 },
        { UnknownError, 500 },
        { InvalidRequest, 400 },
        { InvalidSignature, 400 },
        { InvalidTimeStamp, 400 },
        { InvalidApiKeyOrIp, 401 },
        { BadApiKeyFmt, 401 },
        { BadHttpMethod, 405 },
        { MediaTypeNotSupported, 415 },
        { InvalidRequestBody, 400 },
        { MandatoryParamEmptyOrMalformed, 400 },
        { InvalidParamWrongLength, 400 },
        { InvalidParamWrongValue, 400 },
        { InvalidParamIllegalChar, 400 },
        { InvalidRequestTooLarge, 413 },
        { InvalidMerchantTradeNo, 400 },
        { InvalidAccountStatus, 403 },
        { SubMerchantInvalid, 403 }
    };
}

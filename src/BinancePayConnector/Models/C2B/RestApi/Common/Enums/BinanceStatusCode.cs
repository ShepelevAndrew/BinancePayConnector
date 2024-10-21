namespace BinancePayConnector.Models.C2B.RestApi.Common.Enums;

/// <summary>
/// It is Binance Pay API status codes, see in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-common#common-business-errors"/>
/// </summary>
public enum BinanceStatusCode
{
    RequestError = 0, // Not binance status code, only for mark request error
    UnknownError = 400000,
    InvalidRequest = 400001,
    InvalidSignature = 400002,
    InvalidTimeStamp = 400003,
    InvalidApiKeyOrIp = 400004,
    BadApiKeyFmt = 400005,
    BadHttpMethod = 400006,
    MediaTypeNotSupported = 400007,
    InvalidRequestBody = 400008,
    MandatoryParamEmptyOrMalformed = 400100,
    InvalidParamWrongLength = 400101,
    InvalidParamWrongValue = 400102,
    InvalidParamIllegalChar = 400103,
    InvalidRequestTooLarge = 400104,
    InvalidMerchantTradeNo = 400201,
    InvalidAccountStatus = 400203,
    SubMerchantInvalid = 400206
}

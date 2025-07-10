using System.ComponentModel;
using BinancePayConnector.Core.Domain.BinanceStatusCode.Attributes;

namespace BinancePayConnector.Core.Domain.BinanceStatusCode;

/// <summary>
/// It is Binance Pay API status codes, see in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-common#common-business-errors"/>
/// </summary>
public enum BinanceStatusCode
{
    [Description("1"), HttpStatus(500)]
    RequestError = 1, // Not binance status code, only for mark request error

    [Description("000000"), HttpStatus(200)]
    Success = 0,

    [Description("400000"), HttpStatus(500)]
    UnknownError = 400000,

    [Description("400001"), HttpStatus(400)]
    InvalidRequest = 400001,

    [Description("400002"), HttpStatus(406)]
    InvalidSignature = 400002,

    [Description("400003"), HttpStatus(406)]
    InvalidTimeStamp = 400003,

    [Description("400004"), HttpStatus(401)]
    InvalidApiKeyOrIp = 400004,

    [Description("400005"), HttpStatus(401)]
    BadApiKeyFmt = 400005,

    [Description("400006"), HttpStatus(405)]
    BadHttpMethod = 400006,

    [Description("400007"), HttpStatus(415)]
    MediaTypeNotSupported = 400007,

    [Description("400008"), HttpStatus(400)]
    InvalidRequestBody = 400008,

    [Description("400100"), HttpStatus(400)]
    MandatoryParamEmptyOrMalformed = 400100,

    [Description("400101"), HttpStatus(400)]
    InvalidParamWrongLength = 400101,

    [Description("400102"), HttpStatus(400)]
    InvalidParamWrongValue = 400102,

    [Description("400103"), HttpStatus(400)]
    InvalidParamIllegalChar = 400103,

    [Description("400104"), HttpStatus(413)]
    InvalidRequestTooLarge = 400104,

    [Description("400201"), HttpStatus(400)]
    InvalidMerchantTradeNo = 400201,

    [Description("400202"), HttpStatus(403)]
    InvalidAccountStatus = 400203,

    [Description("400206"), HttpStatus(403)]
    SubMerchantInvalid = 400206,

    [Description("400606"), HttpStatus(403)]
    MerchantAccessForbidden = 400606,

    [Description("406207"), HttpStatus(404)]
    PaymentDirectDebitContractNotFound = 406207,

    [Description("406212"), HttpStatus(409)]
    PaymentDirectDebitContractNotSigned = 406212
}

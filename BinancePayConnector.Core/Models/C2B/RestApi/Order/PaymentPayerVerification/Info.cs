using BinancePayConnector.Core.Models.C2B.RestApi.Order.PaymentPayerVerification.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.PaymentPayerVerification;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-payer-verification"/>
/// </summary>
/// <param name="Category">
/// Enum value from <see cref="CategoryType"/><br/>
/// - For Individual: FIRST_NAME, LAST_NAME, DATE_OF_BIRTH, NATIONALITY(optional), DOCUMENT_TYPE(optional), DOCUMENT_NUMBER(optional).<br/>
/// - For corporate: COMPANY_NAME, REGISTRATION_NUMBER, REGISTRATION_COUNTRY.
/// </param>
/// <param name="Value">
/// Value of information<br/>
/// - For DOCUMENT_TYPE, available values from <see cref="DocumentType"/>:<br/>
/// ID_CARD/PASSPORT/DRIVING_LICENSE/VISA/CPF/OTHER/BVN_NUMBER/NIN_NUMBER/PAN/BVN_NIN_NUMBER/SMILEID_NATIONAL_ID/ABN/ACN/UA_DIA.<br/>
/// - For DATE_OF_BIRTH format: YYYY-MM-DD.<br/>
/// - For NATIONALITY and REGISTRATION_COUNTRY value is based on 2-letter country code.
/// </param>
public sealed record Info(
    string Category,
    string Value
);
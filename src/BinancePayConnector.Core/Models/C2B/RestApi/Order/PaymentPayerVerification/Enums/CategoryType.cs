namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.PaymentPayerVerification.Enums;

public static class CategoryType
{
    // For individual:
    public const string FirstName = "FIRST_NAME";
    public const string LastName = "LAST_NAME";
    public const string DateOfBirth = "DATE_OF_BIRTH";
    public const string Nationality = "NATIONALITY";
    public const string DocumentType = "DOCUMENT_TYPE";
    public const string DocumentNumber = "DOCUMENT_NUMBER";

    // For corporate:
    public const string CompanyName = "COMPANY_NAME";
    public const string RegistrationNumber = "REGISTRATION_NUMBER";
    public const string RegistrationCountry = "REGISTRATION_COUNTRY";
}

using EventPilot.Domain.Common;
using EventPilot.Domain.Enums;

namespace EventPilot.Domain.Entities;

public class TenantApplication : BaseEntity
{
    public string CompanyName { get; private set; } = string.Empty;
    public string TaxCode { get; private set; } = string.Empty;
    public string BusinessEmail { get; private set; } = string.Empty;
    public string PhoneNumner { get; private set; } = string.Empty;
    public TenantStatus Status { get; private set; } = TenantStatus.PendingKyb;

    public string ContactName { get; private set; } = string.Empty;
    public string ContactTitle { get; private set; } = string.Empty;

    public string? InternalNote { get; private set; }
    public string? RejectedReason { get; private set; }

    private TenantApplication()
    {
    }

    public static TenantApplication Create(string companyName, string taxCode, string businessEmail, string phoneNumner,
        string contactName, string contactTitle)
    {
        if (string.IsNullOrWhiteSpace(companyName))
            throw new ArgumentException($"nameof{companyName} cannot be empty", nameof(companyName));
        if (string.IsNullOrWhiteSpace(taxCode))
            throw new ArgumentException($"nameof(taxCode) cannot be empty", nameof(taxCode));
        if (string.IsNullOrWhiteSpace(businessEmail))
            throw new ArgumentException($"businessEmail cannot be empty", nameof(businessEmail));
        if (string.IsNullOrWhiteSpace(phoneNumner))
            throw new ArgumentException($"phoneNumner cannot be empty", nameof(phoneNumner));
        if (string.IsNullOrWhiteSpace(contactName))
            throw new ArgumentException($"nameof{contactName} cannot be empty", nameof(contactName));
        if (string.IsNullOrWhiteSpace(contactTitle))
            throw new ArgumentException($"nameof(contactTitle) cannot be empty", nameof(contactTitle));

        return new TenantApplication
        {
            CompanyName = companyName,
            TaxCode = taxCode,
            BusinessEmail = businessEmail,
            PhoneNumner = phoneNumner,
            ContactName = contactName,
            ContactTitle = contactTitle,
        };
    }

    public void UpdateProfile(string newCompanyName, string newTaxCode, string newBusinessEmail, string newPhoneNumner,
        string newContactName, string newContactTitle)
    {
        CompanyName = newCompanyName;
        TaxCode = newTaxCode;
        BusinessEmail = newBusinessEmail;
        PhoneNumner = newPhoneNumner;
        ContactName = newContactName;
        ContactTitle = newContactTitle;
    }
}
using EventPilot.Domain.Enums;
using EventPilot.Domain.Common;

namespace EventPilot.Domain.Entities;

public class TenantDocument : BaseEntity
{
    public Guid TenantApplicationId { get; private set; }
    public DocumentType DocumentType { get; private set; }
    public string FileUrl { get; private set; } = string.Empty;
    public string FileName { get; private set; } = string.Empty;
    public DocumentStatus DocumentStatus { get; private set; } = DocumentStatus.Pending;
    public TenantApplication TenantApplication { get; private set; }

    private TenantDocument()
    {
    }

    public static TenantDocument Create(Guid tenantApplicationId, DocumentType documentType, string fileUrl,
        string fileName)
    {
        if (tenantApplicationId == Guid.Empty)
            throw new ArgumentException($"nameof(tenantApplicationId) cannot be empty", nameof(tenantApplicationId));
        if (!Enum.IsDefined(typeof(DocumentType), documentType))
            throw new ArgumentException($"Invalid document type: {documentType}", nameof(documentType));
        if (string.IsNullOrWhiteSpace(fileUrl))
            throw new ArgumentException($"nameof(fileUrl) is required", nameof(fileUrl));
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException($"nameof(fileName) is required", nameof(fileName));

        return new TenantDocument
        {
            TenantApplicationId = tenantApplicationId,
            DocumentType = documentType,
            FileUrl = fileUrl,
            FileName = fileName
        };
    }

    public void UpdateDocumentProfile(string newTenantAppicationId, DocumentType documentType, string fileUrl,
        string fileName)
    {
        TenantApplicationId = Guid.Parse(newTenantAppicationId);
        DocumentType = documentType;
        FileUrl = fileUrl;
        FileName = fileName;
    }
}
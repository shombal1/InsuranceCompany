namespace InsuranceCompany.Web.Models.Contract;

public record CreateContractDto (
    DateTime DateCreate,
    DateTime DateSign,
    int ProductId,
    DateTime DateBegin,
    DateTime DateEnd,
    Decimal Premium,
    Decimal InsuranceSum,
    int AgentId,
    Decimal Rate,
    Decimal Commission,
    int Status,
    int PolicyHolderId,
    int InsuredPersonId,
    int OwnerId
);
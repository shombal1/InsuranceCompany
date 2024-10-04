using InsuranceCompany.Domain.Enum;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateContractUseCase;

public record CreateContractCommand : IRequest<int>
{
    public DateTime DateSign { get; set; }
    public int ProductId { get; set; }
    public DateTime DateBegin { get; set; }
    public DateTime DateEnd { get; set; }
    public Decimal Premium { get; set; }
    public Decimal InsuranceSum { get; set; }
    public int AgentId { get; set; }
    public Decimal Rate { get; set; }
    public Decimal Commission { get; set; }
    public ContractStatus Status { get; set; }
    public int PolicyHolderId { get; set; }
    public int InsuredPersonId { get; set; }
    public int OwnerId { get; set; }
}
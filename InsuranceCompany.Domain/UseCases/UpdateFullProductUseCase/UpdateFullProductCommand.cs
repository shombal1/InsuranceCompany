using MediatR;

namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public class UpdateFullProductCommand : IRequest<Unit>
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LOBId { get; set; }
    public bool Active { get; set; }
    public List<UpdateItemBaseCommand> Items { get; set; }
    public List<UpdateProductRiskCommand> Risks { get; set; }
    public string Formula { get; set; }
}
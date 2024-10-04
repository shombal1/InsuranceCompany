using InsuranceCompany.Domain.Models.Items;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public record SaveProductCommand(string Name, string Description, int LOBId,bool Active, List<CreateItemBaseCommand> Items,
    List<CreateProductRiskCommand> Risks, string Formula) : IRequest<int>;
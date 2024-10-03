using InsuranceCompany.Domain.Models.Items;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public record SaveProductCommand(string Name, string Description, int LOBId, List<ItemBaseCommand> Items,
    List<ProductRiskCommand> Risks, string Formula) : IRequest<Unit>;
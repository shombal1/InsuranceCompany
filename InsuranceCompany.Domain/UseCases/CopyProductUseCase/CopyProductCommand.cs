using MediatR;

namespace InsuranceCompany.Domain.UseCases.CopyProductUseCase;

public record CopyProductCommand(int ProductId) : IRequest<int>;
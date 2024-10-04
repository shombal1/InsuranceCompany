using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetActiveProductsUseCase;

public record GetActiveProductsQuery() : IRequest<IEnumerable<ActiveProduct>>;
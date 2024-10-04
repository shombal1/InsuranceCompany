using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetProductsUseCase;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
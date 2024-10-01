using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetProducts;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
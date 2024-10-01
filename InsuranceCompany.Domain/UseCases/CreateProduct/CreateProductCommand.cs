using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateProduct;

public record CreateProductCommand(string Name) : IRequest<Product>;
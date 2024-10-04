using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.EditProductUseCase;

public record EditProductQuery(int ProductId) : IRequest<EditProduct>;
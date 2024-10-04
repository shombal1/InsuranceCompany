using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateProductUseCase;

public record CreateProductQuery(): IRequest<IEnumerable<LOB>>;
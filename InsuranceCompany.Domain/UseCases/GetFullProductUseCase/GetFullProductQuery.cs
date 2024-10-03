using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetFullProductUseCase;

public record GetFullProductQuery(int ProductId) : IRequest<FullProduct>;
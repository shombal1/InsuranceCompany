using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetIkpUseCase;

public record GetIkpQuery(int Id) : IRequest<Ikp> { }
using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetContractUseCase;

public record GetContractQuery(int Id) : IRequest<Contract> { }
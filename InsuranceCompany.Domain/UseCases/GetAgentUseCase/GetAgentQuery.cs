using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetAgentUseCase;

public record GetAgentQuery(int Id) : IRequest<Agent> {}
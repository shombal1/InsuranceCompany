using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetAgentsUseCase;

public record GetAgentsQuery : IRequest<IEnumerable<Agent>> { }
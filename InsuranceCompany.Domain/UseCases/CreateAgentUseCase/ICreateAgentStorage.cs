using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.CreateAgentUseCase;

public interface ICreateAgentStorage
{
    public Task<int> Create(Agent agent, CancellationToken cancellationToken);
}
using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.GetAgentUseCase;

public interface IGetAgentStorage
{
    public Task<Agent> Get(int id, CancellationToken cancellationToken);
    public Task<IEnumerable<Agent>> Get(CancellationToken cancellationToken);
}
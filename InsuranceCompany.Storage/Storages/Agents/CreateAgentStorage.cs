using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateAgentUseCase;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Storages.Agents;

internal class CreateAgentStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : ICreateAgentStorage
{
    public async Task<int> Create(Agent agent, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<AgentEntity>(agent);

        var entityEntry = await dbContext.Agents.AddAsync(entity, cancellationToken);

        await dbContext.SaveChangesAsync();

        return entityEntry.Entity.Id;
    }
}
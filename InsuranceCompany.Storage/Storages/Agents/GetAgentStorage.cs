using AutoMapper;
using AutoMapper.QueryableExtensions;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetAgentUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages.Agents;

internal class GetAgentStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : IGetAgentStorage
{
    public async Task<Agent> Get(int id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Agents.FindAsync(id, cancellationToken);

        var agent = mapper.Map<Agent>(entity);

        return agent;
    }

    public async Task<IEnumerable<Agent>> Get(CancellationToken cancellationToken)
    {
        return await dbContext.Agents
            .ProjectTo<Agent>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }
}
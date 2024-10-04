using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetAgentUseCase;

namespace InsuranceCompany.Storage.Storages.Agents;

internal class GetAgentStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : IGetAgentStorage
{
    public async Task<Agent> Get(int id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Faces.FindAsync(id, cancellationToken);

        var agent = mapper.Map<Agent>(entity);

        return agent;
    }
}
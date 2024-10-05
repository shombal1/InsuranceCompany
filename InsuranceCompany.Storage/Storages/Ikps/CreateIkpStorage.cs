using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateIkpUseCase;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Storages.Ikps;

internal class CreateIkpStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : ICreateIkpStorage
{
    public async Task<int> Create(Ikp ikp, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<IKPEntity>(ikp);

        var entityEntry = await dbContext.IKPs.AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return entityEntry.Entity.Id;
    }
}
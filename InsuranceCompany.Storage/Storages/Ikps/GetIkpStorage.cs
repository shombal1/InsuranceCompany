using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetIkpUseCase;

namespace InsuranceCompany.Storage.Storages.Ikps;

internal class GetIkpStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : IGetIkpStorage
{
    public async Task<Ikp> Get(int id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.IKPs.FindAsync(id);

        var face = mapper.Map<Ikp>(entity);

        return face;
    }
}
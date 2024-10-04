using AutoMapper;
using AutoMapper.QueryableExtensions;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateProductUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

public class GetLobsStorage(InsuranceCompanyDbContext dbContext,IMapper mapper): IGetLobsStorage
{
    public async Task<IEnumerable<LOB>> Get(CancellationToken cancellationToken)
    {
        return await dbContext.LOBs
            .ProjectTo<LOB>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }
}
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateProductUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

public class GetLobsStorage(InsuranceCompanyDbContext dbContext,IMapper mapper): IGetLobsStorage
{
    public async Task<IEnumerable<Lob>> Get(CancellationToken cancellationToken)
    {
        return await dbContext.LOBs.ProjectTo<Lob>(mapper.ConfigurationProvider).ToArrayAsync(cancellationToken);
    }
}
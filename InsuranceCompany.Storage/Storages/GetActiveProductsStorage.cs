using AutoMapper;
using AutoMapper.QueryableExtensions;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetActiveProductsUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

public class GetActiveProductsStorage(
    InsuranceCompanyDbContext dbContext,
    IMapper mapper) : IGetActiveProductsStorage
{
    public async Task<IEnumerable<ActiveProduct>> Get(CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .Where(p => p.Active == true)
            .ProjectTo<ActiveProduct>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }
}
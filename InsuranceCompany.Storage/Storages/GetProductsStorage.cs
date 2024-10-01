using AutoMapper;
using AutoMapper.QueryableExtensions;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetProducts;
using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

internal class GetProductsStorage(InsuranceCompanyDbContext dbContext,IMapper mapper) : IGetProductsStorage
{
    public async Task<IEnumerable<Product>> Get(CancellationToken cancellationToken)
    {
        return await dbContext.Products.ProjectTo<Product>(mapper.ConfigurationProvider).ToArrayAsync(cancellationToken);
    }
}
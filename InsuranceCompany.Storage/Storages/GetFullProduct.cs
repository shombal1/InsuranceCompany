using AutoMapper;
using AutoMapper.QueryableExtensions;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.EditProductUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

public class GetFullProduct(InsuranceCompanyDbContext dbContext,IMapper mapper) : IGetFullProduct
{
    public Task<FullProduct> Get(int productId, CancellationToken cancellationToken)
    {
        return dbContext.Products
            .Where(p => p.Id == productId)
            .Include(p=>p.LOB)
            .Include(p => p.ProductMetafield)
            .Include(p => p.ProductRisks)
            .ProjectTo<FullProduct>(mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
        
        
    }
}
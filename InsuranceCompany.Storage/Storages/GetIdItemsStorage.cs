using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

public class GetIdItemsStorage(InsuranceCompanyDbContext dbContext) : IGetIdItemsStorage
{
    public async Task<IEnumerable<int>> Get(int productId, CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .Where(p => p.Id == productId)
            .SelectMany(p => p.ProductMetafield)
            .Select(m => m.Id)
            .ToArrayAsync(cancellationToken);

    }
}
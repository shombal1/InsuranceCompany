using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

public class DeleteItemStorage(InsuranceCompanyDbContext dbContext) : IDeleteItemStorage
{
    public async Task Delete(IEnumerable<int> ids,CancellationToken cancellationToken)
    {  
        await dbContext.ProductsMetafield
            .Where(p=>ids.Contains(p.Id))
            .ExecuteDeleteAsync(cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
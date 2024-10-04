using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

public class DeleteProductRiskStorage(InsuranceCompanyDbContext dbContext) : IDeleteProductRiskStorage
{
    public async Task Delete(IEnumerable<int> ids,CancellationToken cancellationToken)
    {
        await dbContext.ProductRisks
            .Where(p=>ids.Contains(p.Id))
            .ExecuteDeleteAsync(cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
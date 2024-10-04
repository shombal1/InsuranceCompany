using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage.Storages;

public class UpdateProductStorage(InsuranceCompanyDbContext dbContext) : IUpdateProductStorage
{
    public async Task Update(int id, string name, string description, int LOBId, bool active, string formula,
        CancellationToken cancellationToken)
    {
        await dbContext.Products
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.LOBId, LOBId)
                .SetProperty(p => p.Description, description)
                .SetProperty(p => p.Active, active)
                .SetProperty(p => p.Name, name)
                .SetProperty(p => p.Formula, formula), cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
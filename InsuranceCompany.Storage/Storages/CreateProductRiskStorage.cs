using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Storages;

public class CreateProductRiskStorage(InsuranceCompanyDbContext dbContext) : ICreateProductRiskStorage
{
    public async Task Crete(int productId,string key, string name, decimal? premium, decimal? insuranceSum, bool active,
        CancellationToken cancellationToken)
    {
        await dbContext.ProductRisks.AddAsync(new ProductRiskEntity()
        {
            ProductId = productId,
            Key = key,
            Name = name,
            Premium = premium,
            InsuranceSum = insuranceSum,
            Active = active
        },cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
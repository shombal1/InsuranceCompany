using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.GetProducts;

public interface IGetProductsStorage : IStorage
{
    public Task<IEnumerable<Product>> Get(CancellationToken cancellationToken);
}
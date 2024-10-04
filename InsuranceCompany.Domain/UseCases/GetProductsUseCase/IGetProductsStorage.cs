using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.GetProductsUseCase;

public interface IGetProductsStorage : IStorage
{
    public Task<Product> Get(int productId, CancellationToken cancellationToken);
    public Task<IEnumerable<Product>> Get(CancellationToken cancellationToken);
}
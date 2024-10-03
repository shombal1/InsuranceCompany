using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.GetFullProductUseCase;

public interface IGetFullProduct: IStorage
{
    public Task<FullProduct> Get(int productId, CancellationToken cancellationToken);
}
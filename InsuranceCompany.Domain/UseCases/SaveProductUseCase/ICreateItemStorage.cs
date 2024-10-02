using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public interface ICreateItemStorage : IStorage
{
    public Task Create(int productId,ItemBase item, CancellationToken cancellationToken);
}
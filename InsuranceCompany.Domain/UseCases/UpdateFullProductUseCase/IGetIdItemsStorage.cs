namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public interface IGetIdItemsStorage : IStorage
{
    public Task<IEnumerable<int>> Get(int productId,CancellationToken cancellationToken);
}
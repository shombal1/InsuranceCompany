namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public interface IDeleteItemStorage : IStorage
{
    public Task Delete(IEnumerable<int> ids,CancellationToken cancellationToken);
}
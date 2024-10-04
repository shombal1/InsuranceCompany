namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public interface IDeleteProductRiskStorage : IStorage
{
    public Task Delete(IEnumerable<int> ids,CancellationToken cancellationToken);
}
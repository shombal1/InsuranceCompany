namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public interface ICreateProductRiskStorage : IStorage
{
    public Task Crete(int productId,string key,string name,decimal? premium,decimal? insuranceSum,bool active,CancellationToken cancellationToken);
}
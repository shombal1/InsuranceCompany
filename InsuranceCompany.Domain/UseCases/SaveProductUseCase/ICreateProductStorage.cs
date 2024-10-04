using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public interface ICreateProductStorage :IStorage
{
    public Task<Product> Create(bool active,string name,string description,int LOBId,string formula,CancellationToken cancellationToken);
}
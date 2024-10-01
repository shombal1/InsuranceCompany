using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.CreateProduct;

public interface ICreateProductStorage : IStorage
{
    public Task<Product> Create(string name);
}
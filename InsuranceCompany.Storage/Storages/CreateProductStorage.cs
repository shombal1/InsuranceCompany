using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateProduct;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Storages;

internal class CreateProductStorage(InsuranceCompanyDbContext dbContext,IMapper mapper) : ICreateProductStorage
{
    public async Task<Product> Create(string name)
    {
        var product = new ProductEntity(){Name = name};
        
        return await Task.FromResult(mapper.Map<Product>(product));
    }
}
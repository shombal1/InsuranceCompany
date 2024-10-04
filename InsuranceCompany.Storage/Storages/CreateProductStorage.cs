using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Storages;

public class CreateProductStorage(InsuranceCompanyDbContext dbContext,IMapper mapper) : ICreateProductStorage
{
    public async Task<Product> Create(bool active,string name, string description, int LOBId, string formula, CancellationToken cancellationToken)
    {
        var product = (await dbContext.Products.AddAsync(new ProductEntity()
        {
            Description = description,
            Formula = formula,
            Name = name,
            LOBId = LOBId,
            Active = active
        },cancellationToken)).Entity;

        await dbContext.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<Product>(product);
    }
}
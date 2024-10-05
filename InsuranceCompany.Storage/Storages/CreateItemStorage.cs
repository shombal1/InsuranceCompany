using System.Text.Json;
using AutoMapper;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Storage.Entities;
using InsuranceCompany.Storage.Enums;
using InsuranceCompany.Storage.Models;

namespace InsuranceCompany.Storage.Storages;

public class CreateItemStorage(InsuranceCompanyDbContext dbContext) : ICreateItemStorage
{
    public async Task Create(int productId,ItemBase item, CancellationToken cancellationToken)
    {
        await dbContext.ProductsMetafield.AddAsync(new ProductMetafieldEntity()
        {
            ProductId = productId,
            Type = item.Type switch
            {
                ItemType.ComboBox => ProductMetafieldType.ComboBox,
                ItemType.InputBox => ProductMetafieldType.InputBox,
                _ => throw new ArgumentOutOfRangeException()
            },
            JsonData = JsonSerializer.Serialize(item, item.GetType())
        },cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
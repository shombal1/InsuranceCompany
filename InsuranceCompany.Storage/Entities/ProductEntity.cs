namespace InsuranceCompany.Storage.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public int LOBId { get; set; }
    public LOBEntity LOB { get; set; } = null!;

    public ICollection<ProductMetafieldEntity> ProductMetafield { get; set; } = null!;
    
    public ICollection<ContractEntity> Contracts { get; set; } = null!;
}
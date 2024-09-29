using InsuranceCompany.Storage.Enums;

namespace InsuranceCompany.Storage.Entities;
                    
public class ProductMetafieldEntity 
{
    public int Id { get; set; }
    public ProductMetafieldType Type { get; set; } 
    public string JsonData { get; set; } = null!;
    
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}
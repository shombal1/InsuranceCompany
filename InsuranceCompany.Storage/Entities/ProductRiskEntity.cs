namespace InsuranceCompany.Storage.Entities;

public class ProductRiskEntity
{
    public int Id { get; set; }
    
    public string Key { get; set; }
    public string Name { get; set; } = null!;
    public decimal? Premium { get; set; } 
    public decimal? InsuranceSum { get; set; } 
    public bool Active { get; set; }
    
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}
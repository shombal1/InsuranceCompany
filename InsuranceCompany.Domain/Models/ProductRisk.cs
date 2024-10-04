namespace InsuranceCompany.Domain.Models;

public class ProductRisk
{
    public int Id { get; set; }
    public string Key { get; set; } 
    public string Name { get; set; } 
    public decimal? Premium { get; set; } 
    public decimal? InsuranceSum { get; set; } 
    public bool Active { get; set; }
}
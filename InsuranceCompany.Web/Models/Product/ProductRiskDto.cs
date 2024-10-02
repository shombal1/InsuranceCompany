namespace InsuranceCompany.Web.Models.Product;

public class ProductRiskDto
{
    public string Name { get; set; }
    public string Key { get; set; }
    public decimal? Premium { get; set; } 
    public decimal? InsuranceSum { get; set; } 
    public bool Active { get; set; }
}
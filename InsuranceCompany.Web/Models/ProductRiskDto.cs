namespace InsuranceCompany.Web.Models;

public class ProductRiskDto
{
    public string Name { get; set; }
    public string Key { get; set; }
    public string Description { get; set; }
    public decimal? Premium { get; set; } 
    public decimal? InsuranceSum { get; set; } 
    public bool Active { get; set; }
}
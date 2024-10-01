namespace InsuranceCompany.Web.Models;

public class CreateProductDto
{
    public string Nmae { get; set; }
    public string Description { get; set; }
    public int LodId { get; set; }
    
    public List<ItemBaseDto> Items { get; set; }
    public List<ProductRiskDto> Risks { get; set; }
    
    public string Formula { get; set; }
}
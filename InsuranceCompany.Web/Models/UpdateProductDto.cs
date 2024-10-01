namespace InsuranceCompany.Web.Models;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Nmae { get; set; }
    public string Description { get; set; }
    public int LodId { get; set; }
    
    public List<ItemBaseDto> Items { get; set; }
    
    public string Formula { get; set; }
}
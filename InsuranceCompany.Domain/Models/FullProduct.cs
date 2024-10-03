using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.Models;

public class FullProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string NameLOB { get; set; }
    public int LOBID { get; set; }
    public bool Active { get; set; }
    
    public List<ItemBase> Items { get; set; }
    public List<ProductRisk> Risks { get; set; }
    
    public string Formula { get; set; }
}
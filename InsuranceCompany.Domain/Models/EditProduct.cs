using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.Models;

public class EditProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string NameLOB { get; set; }
    public int LOBId { get; set; }
    public bool Active { get; set; }
    
    public ICollection<ItemBase> Items { get; set; }
    public ICollection<ProductRisk> Risks { get; set; }
    public ICollection<LOB> LOBs { get; set; }
    
    public string Formula { get; set; }
}
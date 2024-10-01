namespace InsuranceCompany.Web.Models.Product;

public class ItemBaseDto
{
    public int Index { get; set; }
    public string Key { get; set; }
    public double Value { get; set; }
    public string Description { get; set; }
    public virtual ItemType Type { get; set; }
}
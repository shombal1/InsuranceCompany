namespace InsuranceCompany.Web.Models;

public class ItemBaseDto
{
    public string Key { get; set; }
    public double Value { get; set; }
    public string Description { get; set; }
    public virtual ItemType Type { get; set; }
}
namespace InsuranceCompany.Web.Models;

public class ItemInputBoxDto : ItemBaseDto
{
    public override ItemType Type { get; set; } = ItemType.InputBox;
    
    public double Minvalue { get; set; }
}
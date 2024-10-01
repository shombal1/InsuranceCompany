namespace InsuranceCompany.Web.Models.Product;

public class ItemInputBoxDto : ItemBaseDto
{
    public override ItemType Type { get; set; } = ItemType.InputBox;
}
namespace InsuranceCompany.Web.Models.Item;

public class ItemInputBoxDto : ItemBaseDto
{
    public override ItemType Type { get; set; } = ItemType.InputBox;
}
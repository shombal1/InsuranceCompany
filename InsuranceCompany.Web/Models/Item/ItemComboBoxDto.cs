namespace InsuranceCompany.Web.Models.Item;

public class ItemComboBoxDto : ItemBaseDto
{
    public override ItemType Type { get; set; } = ItemType.ComboBox;
    public List<ComboBoxValue> Values { get; set; }
}
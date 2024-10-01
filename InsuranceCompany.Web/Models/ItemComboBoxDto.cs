namespace InsuranceCompany.Web.Models;

public class ItemComboBoxDto : ItemBaseDto
{
    public override ItemType Type { get; set; } = ItemType.ComboBox;
    
    public List<(string text,double value)> Values { get; set; }
}
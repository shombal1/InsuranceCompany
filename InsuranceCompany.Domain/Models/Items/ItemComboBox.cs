

namespace InsuranceCompany.Domain.Models.Items;

public class ItemComboBox : ItemBase
{
    public override ItemType Type { get; set; } = ItemType.ComboBox;
    
    public List<ComboBoxValue> Values { get; set; }
}

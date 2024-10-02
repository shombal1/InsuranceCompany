
namespace InsuranceCompany.Domain.Models.Items;

public class ItemInputBox  : ItemBase
{
    public override ItemType Type { get; set; } = ItemType.InputBox;
}
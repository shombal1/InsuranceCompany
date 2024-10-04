using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public class CreateItemComboBoxCommand : CreateItemBaseCommand
{
    public override ItemType Type { get; set; } = ItemType.ComboBox;
    public List<ComboBoxValue> Values { get; set; }
}
using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public class UpdateItemComboBoxCommand : UpdateItemBaseCommand
{
    public override ItemType Type { get; set; } = ItemType.ComboBox;
    public List<ComboBoxValue> Values { get; set; }
}
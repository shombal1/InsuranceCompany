using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public class CreateItemInputBoxCommand : CreateItemBaseCommand
{
    public override ItemType Type { get; set; } = ItemType.InputBox;
}
using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public class UpdateItemInputBoxCommand : UpdateItemBaseCommand
{
    public override ItemType Type { get; set; } = ItemType.InputBox;
}
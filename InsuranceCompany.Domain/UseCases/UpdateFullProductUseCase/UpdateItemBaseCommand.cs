using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public class UpdateItemBaseCommand
{
    public int Index { get; set; }
    public string Key { get; set; }
    public string Description { get; set; }
    public virtual ItemType Type { get; set; }
}
using InsuranceCompany.Domain.Models.Items;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public class CreateItemBaseCommand
{    
    public int Index { get; set; }
    public string Key { get; set; }
    public string Description { get; set; }
    public virtual ItemType Type { get; set; }
}
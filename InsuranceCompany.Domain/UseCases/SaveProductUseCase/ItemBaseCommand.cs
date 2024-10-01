using InsuranceCompany.Domain.Enum;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public class ItemBaseCommand
{
    public int Index { get; set; }
    public string Key { get; set; }
    public double Value { get; set; }
    public string Description { get; set; }
    public ItemType Type { get; set; }
}
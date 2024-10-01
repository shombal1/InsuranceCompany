namespace InsuranceCompany.Storage.Entities;

public class RiskEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<ContractRiskEntity> ContractRisks { get; set; } = null!;
}
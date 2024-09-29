namespace InsuranceCompany.Storage.Entities;

public class ContractRiskEntity
{
    public int Id { get; set; } 

    public decimal? Premium { get; set; } 
    public decimal? InsuranceSum { get; set; } 
    
    public int ContractId { get; set; } 
    public ContractEntity Contract { get; set; } = null!;

    public int RiskId { get; set; } 
    public RiskEntity Risk { get; set; } = null!; 
}
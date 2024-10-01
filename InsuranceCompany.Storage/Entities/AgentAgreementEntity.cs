namespace InsuranceCompany.Storage.Entities;

public class AgentAgreementEntity
{
    public int Id { get; set; }
    public decimal Rate { get; set; } 
    
    public int AgentId { get; set; }
    public AgentEntity Agent { get; set; } = null!;
    
    public int LOBId { get; set; }
    public LOBEntity LOB { get; set; } = null!;
}
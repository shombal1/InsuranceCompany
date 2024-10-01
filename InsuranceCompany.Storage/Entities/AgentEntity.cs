namespace InsuranceCompany.Storage.Entities;

public class AgentEntity
{
    public int Id { get; set; }
    public DateTimeOffset DateCreate { get; set; } 
    public DateTimeOffset? DateBegin { get; set; }
    public DateTimeOffset? DateEnd { get; set; }
    
    public int FaceId { get; set; }
    public FaceEntity Face { get; set; } = null!;
    
    public int IKPId { get; set; }
    public IKPEntity IKP { get; set; } = null!;
    
    public int StatusId { get; set; }
    public StatusAgentContractEntity Status { get; set; } = null!;

    public ICollection<ContractEntity> Contracts { get; set; } = null!;

    public ICollection<AgentAgreementEntity> AgentAgreements { get; set; } = null!;
}
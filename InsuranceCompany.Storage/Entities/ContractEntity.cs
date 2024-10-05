using InsuranceCompany.Domain.Enum;

namespace InsuranceCompany.Storage.Entities;

public class ContractEntity
{
    public int Id { get; set; } 
    public DateTime DateCreate { get; set; }
    public DateTime? DateSign { get; set; } 
    public DateTime? DateBegin { get; set; } 
    public DateTime? DateEnd { get; set; } 
    public decimal? Premium { get; set; } 
    public decimal? InsuranceSum { get; set; } 
    public decimal? Rate { get; set; }
    public decimal? Commission { get; set; }
    
    public ContractStatus Status { get; set; }
    
    public int AgentId { get; set; } 
    public AgentEntity Agent { get; set; } = null!; 
    
    public int ProductId { get; set; } 
    public ProductEntity Product { get; set; } = null!;
    
    public int? PolicyHolderId { get; set; } 
    public FaceEntity? PolicyHolder { get; set; } 
    
    public int? InsuredPersonId { get; set; } 
    public FaceEntity? InsuredPerson { get; set; } 
    
    public int? OwnerId { get; set; } 
    public FaceEntity? Owner { get; set; }

    public ICollection<ContractRiskEntity> ContractRisks { get; set; } = null!;
}
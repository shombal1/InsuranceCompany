using InsuranceCompany.Domain.Enum;

namespace InsuranceCompany.Storage.Entities;

public class FaceEntity
{
    public int Id { get; set; }
    public FaceType Type { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? Lastname { get; set; }
    public DateTime? DateBirth { get; set; }
    public string? Name { get; set; }
    public int? INN { get; set; }

    public AgentEntity AgentEntity { get; set; } = null!;
    
    public ICollection<ContractEntity> PolicyHolderContracts { get; set; } = null!; 
   
    public ICollection<ContractEntity> InsuredPersonContracts { get; set; } = null!; 
    
    public ICollection<ContractEntity> OwnerContracts { get; set; } = null!; 

}
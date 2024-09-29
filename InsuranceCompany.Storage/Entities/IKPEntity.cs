namespace InsuranceCompany.Storage.Entities;

public class IKPEntity
{
    public int Id { get; set; } 
    
    public string Name { get; set; } = null!;

    public ICollection<AgentEntity> Agents { get; set; } = null!;
}
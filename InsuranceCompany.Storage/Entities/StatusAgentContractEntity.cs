namespace InsuranceCompany.Storage.Entities;

public class StatusAgentContractEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<AgentEntity> Agents = null!;
}
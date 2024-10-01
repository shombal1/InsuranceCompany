namespace InsuranceCompany.Storage.Entities;

public class LOBEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = null!;
    public ICollection<AgentAgreementEntity> AgentAgreements { get; set; } = null!;
}
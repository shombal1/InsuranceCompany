using System.Reflection;
using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage;

public class InsuranceCompanyDbContext(DbContextOptions<InsuranceCompanyDbContext> options) : DbContext(options)
{
    public DbSet<AgentAgreementEntity> AgentAgreements { get; set; }
    public DbSet<AgentEntity> Agents { get; set; }
    public DbSet<ContractEntity> Contracts { get; set; }
    public DbSet<ContractRiskEntity> ContractRisks { get; set; }
    public DbSet<FaceEntity> Faces { get; set; }
    public DbSet<IKPEntity> IKPs { get; set; }
    public DbSet<LOBEntity> LOBs { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductMetafieldEntity> ProductsMetafield { get; set; }
    public DbSet<RiskEntity> Risks { get; set; }
    public DbSet<StatusAgentContractEntity> StatusesAgentContracts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(InsuranceCompanyDbContext))!);
        
        base.OnModelCreating(modelBuilder);
    }
}
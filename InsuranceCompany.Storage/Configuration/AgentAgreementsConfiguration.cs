using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class AgentAgreementsConfiguration : IEntityTypeConfiguration<AgentAgreementEntity>
{
    public void Configure(EntityTypeBuilder<AgentAgreementEntity> builder)
    {
        builder.ToTable("AGENT_AGREEMENTS");
        
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();
        

        builder.HasOne(a => a.Agent)
            .WithMany(a => a.AgentAgreements)
            .HasForeignKey(a => a.AgentId);

        builder.HasOne(a => a.LOB)
            .WithMany(l => l.AgentAgreements)
            .HasForeignKey(a => a.LOBId);
    }
}
using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class StatusAgentContractConfiguration : IEntityTypeConfiguration<StatusAgentContractEntity>
{
    public void Configure(EntityTypeBuilder<StatusAgentContractEntity> builder)
    {
        builder.ToTable("STATUSES_AGENT_CONTRACT");
        
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name).HasMaxLength(25);
        
        builder.HasMany(s => s.Agents)
            .WithOne(a => a.Status);
    }
}
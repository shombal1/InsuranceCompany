using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class AgentConfiguration : IEntityTypeConfiguration<AgentEntity>
{
    public void Configure(EntityTypeBuilder<AgentEntity> builder)
    {
        builder.ToTable("AGENTS");
        
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.HasOne(a => a.Face)
            .WithOne(f => f.AgentEntity)
            .HasForeignKey<AgentEntity>(a => a.FaceId);

        builder.HasOne(a => a.IKP)
            .WithMany(i => i.Agents)
            .HasForeignKey(a => a.IKPId);

        builder.HasOne(a => a.Status)
            .WithMany(s => s.Agents)
            .HasForeignKey(a => a.StatusId);

        builder.HasMany(a => a.Contracts)
            .WithOne(c => c.Agent);

        builder.HasMany(a => a.AgentAgreements)
            .WithOne(a => a.Agent);
    }
}
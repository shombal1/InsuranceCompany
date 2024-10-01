using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class RiskConfiguration : IEntityTypeConfiguration<RiskEntity>
{
    public void Configure(EntityTypeBuilder<RiskEntity> builder)
    {
        builder.ToTable("RISKS");
        
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Name).HasMaxLength(50);
        
        builder.HasMany(r => r.ContractRisks)
            .WithOne(c => c.Risk);
    }
}
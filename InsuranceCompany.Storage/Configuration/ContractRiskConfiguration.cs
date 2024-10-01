using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class ContractRiskConfiguration : IEntityTypeConfiguration<ContractRiskEntity>
{
    public void Configure(EntityTypeBuilder<ContractRiskEntity> builder)
    {
        builder.ToTable("CONTRACT_RISKS");
        
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.HasOne(c => c.Contract)
            .WithMany(c => c.ContractRisks)
            .HasForeignKey(c => c.ContractId);
    }
}
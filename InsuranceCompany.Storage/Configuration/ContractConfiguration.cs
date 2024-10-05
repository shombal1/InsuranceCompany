using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class ContractConfiguration : IEntityTypeConfiguration<ContractEntity>
{
    public void Configure(EntityTypeBuilder<ContractEntity> builder)
    {
        builder.ToTable("CONTRACTS");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Status)
            .HasConversion<int>();

        builder.HasOne(c => c.Agent)
            .WithMany(a => a.Contracts)
            .HasForeignKey(a => a.AgentId);

        builder.HasOne(c => c.Product)
            .WithMany(p => p.Contracts)
            .HasForeignKey(c => c.ProductId);

        builder.HasOne(c => c.PolicyHolder)
            .WithMany(f => f.PolicyHolderContracts)
            .HasForeignKey(c => c.PolicyHolderId);

        builder.HasOne(c => c.InsuredPerson)
            .WithMany(f => f.InsuredPersonContracts)
            .HasForeignKey(c => c.InsuredPersonId);

        builder.HasOne(c => c.Owner)
            .WithMany(c => c.OwnerContracts)
            .HasForeignKey(c => c.OwnerId);

        builder.HasMany(c => c.ContractRisks)
            .WithOne(c => c.Contract);
    }
}
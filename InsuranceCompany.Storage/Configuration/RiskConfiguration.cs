using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class RiskConfiguration : IEntityTypeConfiguration<ProductRiskEntity>
{
    public void Configure(EntityTypeBuilder<ProductRiskEntity> builder)
    {
        builder.ToTable("PRODUCT_RISKS");
        
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Name).HasMaxLength(100);

        builder.HasOne(r => r.Product)
            .WithMany(p => p.ProductRisks)
            .HasForeignKey(r => r.ProductId);
    }
}
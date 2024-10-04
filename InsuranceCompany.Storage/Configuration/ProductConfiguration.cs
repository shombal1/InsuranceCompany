using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("PRODUCTS");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name).HasMaxLength(100);

        builder.HasMany(p => p.Contracts)
            .WithOne(c => c.Product);

        builder.HasOne(p => p.LOB)
            .WithMany(l => l.Products)
            .HasForeignKey(p => p.LOBId);

        builder.HasMany(p => p.ProductMetafield)
            .WithOne(p => p.Product);

        builder.HasMany(p => p.ProductRisks)
            .WithOne(r => r.Product);
    }
}
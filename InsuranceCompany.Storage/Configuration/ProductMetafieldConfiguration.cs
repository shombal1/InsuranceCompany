using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class ProductMetafieldConfiguration : IEntityTypeConfiguration<ProductMetafieldEntity>
{
    public void Configure(EntityTypeBuilder<ProductMetafieldEntity> builder)
    {
        builder.ToTable("PRODUCT_METAFIELDS");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.JsonData).HasColumnType("json");
        
        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductMetafield)
            .HasForeignKey(p => p.ProductId);
    }
}
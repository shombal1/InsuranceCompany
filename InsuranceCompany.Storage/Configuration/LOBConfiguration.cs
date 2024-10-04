using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class LOBConfiguration : IEntityTypeConfiguration<LOBEntity>
{
    public void Configure(EntityTypeBuilder<LOBEntity> builder)
    {
        builder.ToTable("LOBS");
        
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(l => l.Name).HasMaxLength(50);
        
        builder.HasMany(l => l.AgentAgreements)
            .WithOne(a => a.LOB);
        
        builder.HasMany(l => l.Products)
            .WithOne(a => a.LOB);
    }
}
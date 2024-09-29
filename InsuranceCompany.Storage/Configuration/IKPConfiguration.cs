using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class IKPConfiguration : IEntityTypeConfiguration<IKPEntity>
{
    public void Configure(EntityTypeBuilder<IKPEntity> builder)
    {
        builder.ToTable("IKPS");
        
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(i => i.Name).HasMaxLength(50);

        builder.HasMany(i => i.Agents)
            .WithOne(a => a.IKP);
    }
}
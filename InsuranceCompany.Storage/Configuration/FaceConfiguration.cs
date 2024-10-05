using InsuranceCompany.Storage.Entities;
using InsuranceCompany.Storage.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceCompany.Storage.Configuration;

public class FaceConfiguration : IEntityTypeConfiguration<FaceEntity>
{
    public void Configure(EntityTypeBuilder<FaceEntity> builder)
    {
        builder.ToTable("FACES");

        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Type)
            .HasConversion<int>();

        builder.Property(f => f.FirstName).HasMaxLength(20);
        builder.Property(f => f.SecondName).HasMaxLength(20);
        builder.Property(f => f.Lastname).HasMaxLength(20);
        builder.Property(f => f.Name).HasMaxLength(50);

        builder.HasOne(f => f.AgentEntity)
            .WithOne(a => a.Face);

        builder.HasMany(f => f.PolicyHolderContracts)
            .WithOne(c => c.PolicyHolder);

        builder.HasMany(f => f.InsuredPersonContracts)
            .WithOne(c => c.InsuredPerson);

        builder.HasMany(f => f.OwnerContracts)
            .WithOne(c => c.Owner);
    }
}
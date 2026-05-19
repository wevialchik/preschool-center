using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nз3.Models;

namespace n33.Data.Configurations;

public class ChildConfiguration : IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Child> builder)
    {
        builder.ToTable("Children");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FullName).IsRequired().HasMaxLength(150);
        builder.Property(c => c.BirthDate).IsRequired();
        builder.Property(c => c.InsuranceNumber).IsRequired().HasMaxLength(20);
        builder.HasIndex(c => c.InsuranceNumber).IsUnique();
    }
}
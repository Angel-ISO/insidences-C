using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.ToTable("Area");
        builder.Property(p => p.Name_Area).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description_Area).IsRequired().HasMaxLength(100);
    }
}
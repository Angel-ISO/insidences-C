using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration;
public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rol");
        builder.Property(p => p.Id_Rol).IsRequired();
        builder.Property(p => p.Name_Rol).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description_Rol).IsRequired().HasMaxLength(100);
    }
}
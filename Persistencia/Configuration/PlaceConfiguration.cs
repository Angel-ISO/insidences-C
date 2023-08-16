using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration;
public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.ToTable("Place");
        builder.Property(p => p.Id_Place).IsRequired();
        builder.Property(p => p.Name_Place).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description_Place).IsRequired().HasMaxLength(100);



              builder.HasOne(y => y.Area)
            .WithMany(l => l.Places)
            .HasForeignKey(z => z.Id_AreaOrigin)
            .IsRequired();
    }
}
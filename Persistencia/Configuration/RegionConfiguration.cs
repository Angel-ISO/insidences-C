using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("regions");

            builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("Id_Region")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.NameRegion)
                .HasColumnName("NombreRegion")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

                  builder.HasOne(p => p.Country)
                .WithMany(p => p.Regions)
                .HasForeignKey(p => p.Id_Pais);
    }
}
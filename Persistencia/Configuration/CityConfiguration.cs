using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("cities");

            builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("Id_City")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.NameCity)
                .HasColumnName("NameCity")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

                  builder.HasOne(p => p.Region)
                .WithMany(p => p.Cities)
                .HasForeignKey(p => p.Id_Region);
    }
}
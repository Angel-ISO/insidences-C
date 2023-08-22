using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("countries");

            builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("IdPais")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.NameCountry)
                .HasColumnName("NombrePais")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();
    }
}
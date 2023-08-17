using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration;
public class DetailIncidenceConfiguration : IEntityTypeConfiguration<DetailIncidence>
{
    public void Configure(EntityTypeBuilder<DetailIncidence> builder)
    {
        builder.ToTable("DetailIncidence");




        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_DetailIncidence")
        .HasColumnType("int")
        .IsRequired();


        builder.Property(p => p.Id_Peripheral)
        .HasColumnName("Id_Peripheral")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Id_TypeIncidence)
        .HasColumnName("Id_TypeIncidence")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Id_LevelIncidence)
        .HasColumnName("Id_LevelIncidence")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Id_State)
        .HasColumnName("Id_State")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Description_DetailIncidence)
        .HasColumnName("Nameneigborhood")
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired();


        builder.HasOne(y => y.Incidence)
        .WithMany(l => l.DetailIncidences)
        .HasForeignKey(z => z.Id)
        .IsRequired();

        builder.HasOne(y => y.State)
        .WithMany(l => l.DetailIncidences)
        .HasForeignKey(z => z.Id_State)
        .IsRequired();

        builder.HasOne(y => y.TypeIncidence)
        .WithMany(l => l.DetailIncidences)
        .HasForeignKey(z => z.Id_TypeIncidence)
        .IsRequired();

        builder.HasOne(y => y.LevelOfIncidence)
        .WithMany(l => l.DetailIncidences)
        .HasForeignKey(z => z.Id_LevelIncidence)
        .IsRequired();

    }
}
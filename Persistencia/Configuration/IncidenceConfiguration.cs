using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration;
public class IncidenceConfiguration : IEntityTypeConfiguration<Incidence>
{
    public void Configure(EntityTypeBuilder<Incidence> builder)
    {
        builder.ToTable("Incidence");

            builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_Incidence")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.Id_person)
            .HasColumnName("Id_User")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.Id_State)
            .HasColumnName("Id_State")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.Id_Area)
            .HasColumnName("Id_Area")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.Id_Place)
            .HasColumnName("Id_Place")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.Date)
            .HasColumnName("DateIncidence")
            .HasColumnType("Date")
            .IsRequired();



            builder.Property(p => p.Description_Incidence)
            .HasColumnName("DescriptionIncidence")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();




            builder.HasOne(y => y.Person)
            .WithMany(l => l.Incidences)
            .HasForeignKey(z => z.Id_person)
            .IsRequired();

            builder.HasOne(y => y.Area)
            .WithMany(l => l.Incidences)
            .HasForeignKey(z => z.Id_Area)
            .IsRequired();

            builder.HasOne(y => y.State)
            .WithMany(l => l.Incidences)
            .HasForeignKey(z => z.Id_State)
            .IsRequired();


         
    }
}
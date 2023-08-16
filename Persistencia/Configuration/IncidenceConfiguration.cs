using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration;
public class IncidenceConfiguration : IEntityTypeConfiguration<Incidence>
{
    public void Configure(EntityTypeBuilder<Incidence> builder)
    {
        builder.ToTable("Incidence");
        builder.Property(p => p.Id_Incidence).IsRequired();
        builder.Property(p => p.Id_User).IsRequired();
        builder.Property(p => p.Id_State).IsRequired();
        builder.Property(p => p.Id_Area).IsRequired();
        builder.Property(p => p.Id_Place).IsRequired();
        builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
        builder.Property(p => p.Description_Incidence).IsRequired().HasMaxLength(100);
         
       
       
             builder.HasOne(y => y.User)
            .WithMany(l => l.Incidences)
            .HasForeignKey(z => z.Id_User)
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
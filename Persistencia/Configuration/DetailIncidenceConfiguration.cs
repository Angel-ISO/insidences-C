using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration;
public class DetailIncidenceConfiguration : IEntityTypeConfiguration<DetailIncidence>
{
    public void Configure(EntityTypeBuilder<DetailIncidence> builder)
    {
        builder.ToTable("DetailIncidence");
        builder.Property(p => p.Id_DetailIncidence).IsRequired();
        builder.Property(p => p.Id_Peripheral).IsRequired();
        builder.Property(p => p.Id_TypeIncidence).IsRequired();
        builder.Property(p => p.Id_LevelIncidence).IsRequired();
        builder.Property(p => p.Id_State).IsRequired();
        builder.Property(p => p.Description_DetailIncidence).IsRequired().HasMaxLength(100);


     builder.HasOne(y => y.Incidence)
            .WithMany(l => l.DetailIncidences)
            .HasForeignKey(z => z.Id_DetailIncidence)
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
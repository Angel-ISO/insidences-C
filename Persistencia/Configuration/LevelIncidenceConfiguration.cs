using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;

public class LevelIncidenceConfiguration : IEntityTypeConfiguration<LevelIncidence> 
{   
    public void Configure(EntityTypeBuilder<LevelIncidence> builder)
    {
        builder.ToTable("LevelIncidence");
        builder.Property(p => p.Id_LevelIncidence).IsRequired();
        builder.Property(p => p.Name_LevelIncidence).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description_LevelIncidence).IsRequired().HasMaxLength(100);
    }
}
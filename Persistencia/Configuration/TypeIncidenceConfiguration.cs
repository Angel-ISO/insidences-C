using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration
{
    public class TypeIncidenceConfiguration : IEntityTypeConfiguration<TypeIncidence>
    {
        public void Configure(EntityTypeBuilder<TypeIncidence> builder)
        {
            builder.ToTable("TypeIncidence");
            builder.Property(p => p.Id_TypeIncidence).IsRequired();
            builder.Property(p => p.Name_TypeIncidence).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description_TypeIncidence).IsRequired().HasMaxLength(100);
        }
    }
}
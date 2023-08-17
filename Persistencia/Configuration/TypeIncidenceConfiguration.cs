using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration
{
    public class TypeIncidenceConfiguration : IEntityTypeConfiguration<TypeIncidence>
    {
        public void Configure(EntityTypeBuilder<TypeIncidence> builder)
        {
            builder.ToTable("TypeIncidence");



                builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("Id_TypeIncidence")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Name_TypeIncidence)
                .HasColumnName("NameTypeIncidence")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();


                builder.Property(p => p.Description_TypeIncidence)
                .HasColumnName("DescroptionTypeIncidence")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
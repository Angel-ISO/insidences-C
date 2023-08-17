using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration;
public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");


            builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_State")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.Description_State)
            .HasColumnName("Description_State")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();
        }
}
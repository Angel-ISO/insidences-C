using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class AreaUserConfiguration : IEntityTypeConfiguration<AreaUser>
{
    public void Configure(EntityTypeBuilder<AreaUser> builder)
    {
        builder.ToTable("AreaUser");
    

                builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("Id_Area_User")
                .HasColumnType("int")
                .IsRequired();



                builder.Property(p => p.Id_Area)
                .HasColumnName("Id_Area")
                .HasColumnType("int")
                .IsRequired();


                builder.Property(p => p.Id_User)
                .HasColumnName("Id_Area")
                .HasColumnType("int")
                .IsRequired();




                builder.HasOne(y => y.User)
                .WithMany(l => l.AreaUsers)
                .HasForeignKey(z => z.Id_User)
                .IsRequired();

                builder.HasOne(y => y.Area)
                .WithMany(l => l.AreaUsers)
                .HasForeignKey(z => z.Id_Area)
                .IsRequired();


          
    }
}
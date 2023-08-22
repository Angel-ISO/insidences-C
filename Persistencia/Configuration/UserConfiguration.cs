using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");


            builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_User")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(p => p.Name_User)
            .HasColumnName("NameUser")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

            builder.Property(p => p.Lastname_User)
            .HasColumnName("LastNameUser")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

           
            builder.Property(p => p.Id_DocumentType)
            .HasColumnName("Id_DocumentType")
            .HasColumnType("int")
            .IsRequired();



            builder.HasOne(e => e.Rol)
            .WithMany(o => o.Users)
            .HasForeignKey(x => x.Id_Rol)
            .IsRequired();

            builder.HasOne(u => u.DocumentType)
            .WithMany(a => a.Users)
            .HasForeignKey(u => u.Id_DocumentType)
            .IsRequired();



    }
}
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

             builder.Property(p => p.Password)
            .HasColumnName("Password")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

            builder.Property(p => p.Email)
            .HasColumnName("Email")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

           
            builder.Property(p => p.Id_DocumentType)
            .HasColumnName("Id_DocumentType")
            .HasColumnType("int")
            .IsRequired();

            builder.HasIndex(p => new{
                p.Name_User,
                p.Email
            }).HasDatabaseName("IX-MiIndice").IsUnique();

         

            builder.HasOne(u => u.DocumentType)
            .WithMany(a => a.Users)
            .HasForeignKey(u => u.Id_DocumentType)
            .IsRequired();



                builder
                .HasMany(p => p.Rols)
                .WithMany(r => r.Users)
                .UsingEntity<UserRol>(
                    
                    j=> j
                    .HasOne(pt =>pt.Rol)
                    .WithMany(t => t.UserRols)
                    .HasForeignKey(ut => ut.RolId),


                    j => j
                    .HasOne(et =>et.User)
                    .WithMany(et => et.UserRols)
                    .HasForeignKey(el => el.UserId),
                    
                    j =>{
                        j.HasKey(t => new {t.UserId, t.RolId} );
                        
                    });
    }
}
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.Property(p => p.Id_User).IsRequired();
        builder.Property(p => p.Name_User).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Lastname_User).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Address_User).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Id_DocumentType).IsRequired();

         
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
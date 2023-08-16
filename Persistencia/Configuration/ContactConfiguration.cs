using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contact");
        builder.Property(p => p.Id_Contact).IsRequired();
        builder.Property(p => p.Id_TypeCon).IsRequired();
        builder.Property(p => p.Id_CategoryContact).IsRequired();
        builder.Property(p => p.Description_Contact).IsRequired().HasMaxLength(100);

    
         builder.HasOne(y => y.User)
            .WithMany(l => l.Contacts)
            .HasForeignKey(z => z.Id_User)
            .IsRequired();

             builder.HasOne(y => y.TypeOfContact)
            .WithMany(l => l.Contacts)
            .HasForeignKey(z => z.Id_TypeCon)
            .IsRequired();

              builder.HasOne(y => y.CategoryContact)
            .WithMany(l => l.Contacts)
            .HasForeignKey(z => z.Id_CategoryContact)
            .IsRequired();

            

    }
}
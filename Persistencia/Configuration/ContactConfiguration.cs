using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contact");



                builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("Id_Contact")
                .HasColumnType("int")
                .IsRequired();


                builder.Property(p => p.Id_TypeCon)
                .HasColumnName("Type_Contact")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Id_CategoryContact)
                .HasColumnName("Category_Contact")
                .HasColumnType("int")
                .IsRequired();


                builder.Property(p => p.Description_Contact)
                .HasColumnName("Description_Contact")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();





                builder.HasOne(y => y.Person)
                .WithMany(l => l.Contacts)
                .HasForeignKey(z => z.Id_Person)
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
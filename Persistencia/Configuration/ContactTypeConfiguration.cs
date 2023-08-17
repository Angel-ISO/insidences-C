using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistencia.Configuration;
public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
{
    public void Configure(EntityTypeBuilder<ContactType> builder)
    {
        builder.ToTable("ContactType");
               


                builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("Id_ContactType")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Name_Contact)
                .HasColumnName("NameContact")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();


                builder.Property(p => p.Description_ContactType)
                .HasColumnName("Description_ContactType")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();      
    }
}
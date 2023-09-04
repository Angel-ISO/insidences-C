using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_User")
        .HasColumnType("int")
        .IsRequired();


        builder.Property(p => p.Name)
        .HasColumnName("Name")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();


        builder.Property(p => p.Lastname)
       .HasColumnName("lastname")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();

        builder.Property(p => p.Id_DocumentType)
        .HasColumnName("document_type")
        .HasColumnType("int")
        .IsRequired();



        builder.HasOne(u => u.DocumentType)
        .WithMany(a => a.Persons)
        .HasForeignKey(u => u.Id_DocumentType)
        .IsRequired();



    }
}
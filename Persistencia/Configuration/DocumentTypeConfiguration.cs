using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.ToTable("DocumentType");
        builder.Property(p => p.Id_DocumentType).IsRequired();
        builder.Property(p => p.Name_DocumentType).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Abbreviation_DocumentType).IsRequired().HasMaxLength(20);
    }
}
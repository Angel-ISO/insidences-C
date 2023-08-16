using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration;
public class CategoryContactConfiguration : IEntityTypeConfiguration<CategoryContact>
{
    public void Configure(EntityTypeBuilder<CategoryContact> builder)
    {
        builder.ToTable("CategoryContact");
        builder.Property(p => p.Id_CategoryContact).IsRequired();
        builder.Property(p => p.Id_Category).IsRequired();
        builder.Property(p => p.Name_CategoryContact).IsRequired().HasMaxLength(50);
    }
}
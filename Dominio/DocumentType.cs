using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class DocumentType : BaseEntity
{
    
    public string ?Name_DocumentType { get; set; }
    public ICollection<Person> ?Persons { get; set; }
    public Contact ? Contact { get; set; }
    public string ?Abbreviation_DocumentType { get; set; }
}
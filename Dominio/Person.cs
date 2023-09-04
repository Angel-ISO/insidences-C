using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class Person : BaseEntity
{
    public ICollection<Address> ?Addresses { get; set; }
    public ICollection<Contact> ?Contacts { get; set; }
    public ICollection<AreaUser> ?AreaUsers { get; set; }
    public ICollection<Incidence> ?Incidences { get; set; }
    public string ?Name { get; set; }
    public string ?Lastname { get; set; }
    public int Id_DocumentType { get; set; }
    public DocumentType ? DocumentType { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class ContactType
{
    [Key]
    public int Id_TypeContact { get; set; }
    public string ?Name_Contact { get; set; }
     public ICollection<Contact> ? Contacts  { get; set; }

    public string ?Description_ContactType { get; set; }
}
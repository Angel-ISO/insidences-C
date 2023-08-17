using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class ContactType : BaseEntity
{
  
    public string ?Name_Contact { get; set; }
     public ICollection<Contact> ? Contacts  { get; set; }

    public string ?Description_ContactType { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class Contact : BaseEntity
{
    public int Id_User { get; set; }
    public User ? User { get; set; }

    public int Id_TypeCon { get; set; }
    public ContactType ? TypeOfContact { get; set; }


    public int Id_CategoryContact { get; set; }
    public CategoryContact ? CategoryContact { get; set; }

    public string ?Description_Contact { get; set; }
}
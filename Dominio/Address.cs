namespace Dominio;

public class Address : BaseEntity
{
    public string ? Neigborhood { get; set; }
    
    public string ? TypeWay  {get; set;}
    public string ? QuadrantPrefix {get; set;}
    public string ?  NumberWay {get; set;}
    public string? NumberVenereableWay {get; set;}
    public string? NumberPlate {get; set;}
    public int Id_Pa {get; set;}
    public Person ? Person {get; set;}
    public int Id_CityA {get; set;}
    public City ? City  {get; set;}
}
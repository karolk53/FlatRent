namespace FlatRent.Entities;

public class HouseDetails
{
    public int Id { get; set; }
    public int Floors { get; set; }
    public int WindowsNumber { get; set; }
    public ICollection<Safety> Safeties { get; set; }
}
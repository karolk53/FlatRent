namespace FlatRent.Entities;

public class FlatDetails
{
    public int Id { get; set; }
    public int RoomsNumber { get; set; }
    public int Floor { get; set; }
    public ICollection<Safety> Safeties { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
}
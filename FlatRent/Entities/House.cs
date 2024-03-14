namespace FlatRent.Entities;

public class House : Property
{
    public int Id { get; set; }
    public Address Address { get; set; }
}
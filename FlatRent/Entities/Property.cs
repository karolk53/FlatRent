namespace FlatRent.Entities;

public class Property
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Surface { get; set; }
    public string Description { get; set; }
    public string ContactPhone { get; set; }
    public string ContactName { get; set; }
    
    public Address Address { get; set; }
    public int AddressId { get; set; }
    
    public AppUser Owner { get; set; }
    public AppUser OwnerId { get; set; }

    public ICollection<AppUser> Tenants { get; set; }

    public FlatDetails FlatDetails { get; set; }
    public HouseDetails HouseDetails { get; set; }
}
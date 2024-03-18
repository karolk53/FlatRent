using Microsoft.AspNetCore.Identity;

namespace FlatRent.Entities;

public class AppUser : IdentityUser<int>
{
    public ICollection<Property> OwnProperties { get; set; }
    public ICollection<Property> RentedProperties { get; set; }
}
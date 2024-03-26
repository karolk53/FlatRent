using FlatRent.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlatRent.Data;

public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
    IdentityUserClaim<int>,AppUserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<HouseDetails> HouseDetails { get; set; }
    public DbSet<FlatDetails> FlatDetails { get; set; }
    public DbSet<Safety> Safeties { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Property>()
            .HasOne<HouseDetails>(hd => hd.HouseDetails)
            .WithOne(p => p.Property)
            .HasForeignKey<HouseDetails>(k => k.PropertyId);

        builder.Entity<Property>()
            .HasOne<FlatDetails>(fd => fd.FlatDetails)
            .WithOne(p => p.Property)
            .HasForeignKey<FlatDetails>(k => k.PropertyId);


    }
}
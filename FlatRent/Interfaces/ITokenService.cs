using FlatRent.Entities;

namespace FlatRent.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}
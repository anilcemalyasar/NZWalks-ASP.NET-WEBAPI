using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Repositories.Abstracts
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}

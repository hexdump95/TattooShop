using Tattoo.Entities;

namespace Tattoo.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}


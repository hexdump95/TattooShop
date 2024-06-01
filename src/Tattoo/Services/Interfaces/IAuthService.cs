using Tattoo.DTOs;

namespace Tattoo.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(RegisterRequest request);
        Task<string> Login(LoginRequest loginRequest);
    }
}

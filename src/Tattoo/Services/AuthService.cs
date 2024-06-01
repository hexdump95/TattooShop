using AutoMapper;

using Tattoo.DTOs;
using Tattoo.Entities;
using Tattoo.Exceptions;
using Tattoo.Repositories.Interfaces;
using Tattoo.Services.Interfaces;

namespace Tattoo.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(
            ILogger<AuthService> logger,
            IJwtService jwtService,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _jwtService = jwtService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> Register(RegisterRequest request)
        {
            bool userExists = _userRepository.ExistsByUsername(request.Username);

            if (userExists)
                throw new GenericException("User already exists");

            User user = _mapper.Map<RegisterRequest, User>(request);
            await _userRepository.Save(user);

            return _jwtService.GenerateToken(user);
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            User user = await _userRepository.FindByUsername(loginRequest.Username)
                        ?? throw new InvalidUserException();

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password);

            if (!isPasswordCorrect)
                throw new InvalidPasswordException();

            return _jwtService.GenerateToken(user);
        }
    }
}

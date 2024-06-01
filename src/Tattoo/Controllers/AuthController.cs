using Microsoft.AspNetCore.Mvc;

using Tattoo.DTOs;
using Tattoo.Exceptions;
using Tattoo.Services.Interfaces;

namespace Tattoo.Controllers
{
    [ApiController]
    [Route("/api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                string accessToken = await _authService.Register(registerRequest);
                RegisterResponse registerResponse = new() { AccessToken = accessToken };
                return Ok(registerResponse);
            }
            catch (Exception e)
            {
                if (e is GenericException)
                {
                    return Conflict(
                        new DefaultMessageResponse { Message = ((GenericException)e).Detail }
                    );
                }
                else
                {
                    _logger.LogDebug(e.ToString());
                    return BadRequest();
                }
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                string accessToken = await _authService.Login(loginRequest);
                LoginResponse loginResponse = new() { AccessToken = accessToken };
                return Ok(loginResponse);
            }
            catch (Exception e)
            {
                if (e is InvalidUserException || e is InvalidPasswordException)
                {
                    _logger.LogDebug(((InvalidUserException)e).Detail);
                    return Unauthorized(new DefaultMessageResponse { Message = "Wrong username or password." });
                }
                else
                {
                    _logger.LogDebug(e.Message);
                    return Forbid();
                }
            }
        }
    }
}

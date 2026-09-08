using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Refrigeracion.Application.DTOs.Identity.User;
using Refrigeracion.Application.DTOs.Login;
using Refrigeracion.Entities.MicrosoftIdentity;
using Refrigeracion.Services.AuthServices;
using Refrigeracion.WebApi.Configurations;

namespace Refrigeracion.WebApi.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenHandlerService _tokenService;

        public AuthController(UserManager<User> userManager, ITokenHandlerService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegistroRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Los datos enviados no son válidos.");
            }

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return BadRequest("Ya existe un usuario registrado con el mail " + request.Email + ".");
            }

            var userName = request.Email.Substring(0, request.Email.IndexOf('@'));

            var newUser = new User
            {
                Email = request.Email,
                UserName = userName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IsActive = true
            };

            var created = await _userManager.CreateAsync(newUser, request.Password);

            if (!created.Succeeded)
            {
                return BadRequest(created.Errors.Select(e => e.Description).ToList());
            }

            return Ok(new UserRegistroResponseDto
            {
                FullName = string.Join(" ", request.FirstName, request.LastName),
                Email = request.Email,
                UserName = userName
            });
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDto request)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(request.Email);
                if (existingUser != null)
                {
                    var isCorrect = await _userManager.CheckPasswordAsync(existingUser, request.Password);
                    if (isCorrect)
                    {
                        var roles = await _userManager.GetRolesAsync(existingUser);

                        var parameters = new TokenParameters
                        {
                            Id = existingUser.Id.ToString(),
                            PasswordHash = existingUser.PasswordHash ?? string.Empty,
                            UserName = existingUser.UserName ?? string.Empty,
                            Email = existingUser.Email ?? string.Empty,
                            Roles = roles
                        };

                        var jwt = _tokenService.GenerateJwtTokens(parameters);

                        return Ok(new LoginUserResponseDto
                        {
                            Login = true,
                            Token = jwt,
                            UserName = existingUser.UserName,
                            Mail = existingUser.Email
                        });
                    }
                }
            }

            return BadRequest(new LoginUserResponseDto
            {
                Login = false,
                Errors = new List<string> { "Usuario o contraseña incorrecto." }
            });
        }
    }
}

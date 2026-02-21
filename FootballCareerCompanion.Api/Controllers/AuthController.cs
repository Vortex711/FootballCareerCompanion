using FootballCareerCompanion.Application.DTOs.Auth;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Application.Interfaces.Security;
using FootballCareerCompanion.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballCareerCompanion.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRequest request)
        {
            var existing = await _userRepository.GetByEmailAsync(request.Email);

            if (existing != null)
                return BadRequest("Email already registered");

            var hashedPassword = _passwordHasher.Hash(request.Password);

            var user = new User(
                id: Guid.NewGuid(),
                email: request.Email.ToLower(),
                passwordHash: hashedPassword,
                createdAt: DateTime.UtcNow);

            await _userRepository.AddAsync(user);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email.ToLower());
            
            if (user == null)
                return Unauthorized("Invalid credentials.");

            var isValid = _passwordHasher.Verify(request.Password, user.PasswordHash);
            if (!isValid)
                return Unauthorized("Invalid credentials.");

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email);

            return Ok(new
            {
                token
            });
        }
    }
}

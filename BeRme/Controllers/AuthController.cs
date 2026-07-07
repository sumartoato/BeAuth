using Microsoft.AspNetCore.Http;
using BeRme.DTO;
using BeRme.Models;
using BeRme.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BeRme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }

        //POST https://localhost:44354/api/Auth/register
        //BODY
        /*{
          "username": "admin",
          "password": "123456",
          "fullName": "Administrator",
          "role": "Admin"
        }*/

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            // 1. Cek username
            var existingUser = await _repository.GetByUsernameAsync(dto.Username);

            if (existingUser != null)
            {
                return BadRequest(new
                {
                    message = "Username already exists."
                });
            }

            // 2. Hash password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // 3. Mapping DTO ke Model
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = passwordHash,
                FullName = dto.FullName,
                Role = dto.Role,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            // 4. Simpan ke database
            await _repository.CreateAsync(user);

            // 5. Response

            return Ok(new
            {
                message = "User registered successfully."
            });
        }
    }
}

using JobSearchTracker.Data;
using JobSearchTracker.Models;
using JobSearchTracker.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace JobSearchTracker.Controllers
{
	public class AccountController : BaseApiController
	{
		private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")] // POST: api/account/controller
        public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.Username)) return BadRequest("Username is not available.");

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerDTO.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key,
                CreatedDate = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDTO loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == loginDto.Username.ToLower());

            

            if (user == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            
            user.LastLoginDate = DateTime.Now;

            return Ok(user);



        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}

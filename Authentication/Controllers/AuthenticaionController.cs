using Authentication.Models;
using Authentication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Authentication.Controllers
{
    [Authorize]
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticaionController : ControllerBase
    {
        private readonly IRepository _repository;

        public AuthenticaionController(IRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult AddUser(SignUpDto signIn)
        {
            var hashedPassword = PasswordManager.HashPassword(signIn.Password);

            var user = new User
            {
                UserName = signIn.UserName,
                Password = hashedPassword,
                Email = signIn.Email
            };

            _repository.AddUser(user);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult SignIn(SignInDto signIn)
        {
            var user = _repository.GetUser(signIn.UserName);
            if (user == null)
                return NotFound("User not found");
            var isUser = _repository.AuthenticateUser(signIn.Password, user.Password);
            if (!isUser)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, signIn.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = signIn.RememberPassword }
                );
            return Ok("Sign in successful");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Sign out successful");
        }
    }
}

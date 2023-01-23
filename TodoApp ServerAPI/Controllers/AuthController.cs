
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TodoApp_ServerAPI.Data.DTOs;
using TodoApp_ServerAPI.Data.Interfaces;
using TodoApp_ServerAPI.Helpers;
using TodoApp_ServerAPI.Model;

namespace auth.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _jwtService = jwtService;
            _repository = repository;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName
            };
            return Created("User created", _repository.CreateUser(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var user = _repository.GetUserByUserName(loginDto.userName);
            if (user.Result == null)
            {
                return BadRequest(new { message = "Invalid username" });
            }

            TokenResponse tokenResponse = new TokenResponse();

            var jwt = _jwtService.Generate(user.Result.UserId);

            tokenResponse.JWTToken = jwt;
            tokenResponse.UserName = user.Result.UserName;

            return Ok(tokenResponse);
        }

        [HttpPost("user")]
        public IActionResult User(TokenResponse token)
        {
            try
            {
                var securityToken = _jwtService.Verify(token.JWTToken);
                var userName = securityToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "success"
            });
        }
    }
}

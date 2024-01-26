using BusinessLayer.Unity;
using ECommerceAPI.Auth;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;

        private readonly ITokenService _tokenService;
        public LoginController(IUnitOfWork UnitOfWork, ITokenService tokenService)
        {
            _IUnitOfWork = UnitOfWork;
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel is null)
            {
                return BadRequest("Invalid client request");
            }
            var user = _IUnitOfWork.usersRepo.GetAll().Where(u =>
                (u.UserName == loginModel.UserName) && (u.Password == loginModel.Password)).FirstOrDefault();
            if (user is null)
                return Unauthorized();
            var userRole = _IUnitOfWork.usersRoleRepo.GetRolesByUserId(user.Id);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("UserId", user.Id.ToString()),

        };
            foreach (var role in userRole)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.RoleNameEn));
            }
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            _IUnitOfWork.Complete();
            return Ok(new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}

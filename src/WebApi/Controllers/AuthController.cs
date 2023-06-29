using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Core;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost(Name = "Login")]
        [AllowAnonymous]
        public async Task<CustomActionResult> Login(TokenReq req)
        {
            var objResult = await _authService.LoginUser(req);
            return new CustomActionResult(true, null, objResult, 100);
        }
      
    }
}

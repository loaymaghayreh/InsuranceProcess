using Insurance.Application.Service.Interface;
using Insurance.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProcess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthAppService _authService;
        public AuthController(IAuthAppService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            // Validate user credentials (this example uses hardcoded validation)
            if (loginDto.UserName == "test" && loginDto.Password == "password")
            {
                var token = _authService.GenerateJwtToken(loginDto.UserName);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}

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

        [HttpPost("Token")]
        public IActionResult GetToken([FromBody] LoginDto loginDto)
        {
            // Validate user credentials (this example uses hardcoded validation)
            if (loginDto.UserName == "admin" && loginDto.Password == "admin@123")
            {
                var token = _authService.GenerateJwtToken(loginDto.UserName);
                return Ok(new { token = "Bearer " + token });
            }

            return Unauthorized();
        }
    }
}

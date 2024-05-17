using Insurance.Application.Service.Interface;
using Insurance.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProcess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerInsuranceApplication : ControllerBase
    {
        private ICustomerApplicationAppService _customerApplicationAppService;
        public CustomerInsuranceApplication(ICustomerApplicationAppService customerApplicationAppService)
        {
            _customerApplicationAppService = customerApplicationAppService;
        }

        [HttpPost("SaveInsuranceForm")]
        public async Task<IActionResult> CreateCustomerInsuranceApplication([FromBody] CustomerApplicationDto applicationDto)
        {
            //use Gard Helper 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _customerApplicationAppService.CreateCustomerInsuranceApplicationAsync(applicationDto);
                return Ok("Customer application created successfully.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

using Insurance.Application.Service.Interface;
using Insurance.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProcess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerInsuranceApplication : Controller
    {
        public IInsuranceAppService _insuranceAppService;
        public CustomerInsuranceApplication(IInsuranceAppService insuranceAppService)
        {
            _insuranceAppService = insuranceAppService;
        }

        [HttpPost]
        public IActionResult CreateCustomerInsuranceApplication([FromBody] CustomerApplicationDto applicationDto)
        {
            if (!ModelState.IsValid)
            {
                // Return bad request if model state is invalid
                return BadRequest(ModelState);
            }

            try
            {
                // Assuming your service layer handles the conversion from DTO to domain model and persists it
                _insuranceAppService.CreateCustomerInsuranceApplication(applicationDto);

                // You might want to return a specific object or just a success status code
                return Ok("Customer application created successfully.");
            }
            catch (System.Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

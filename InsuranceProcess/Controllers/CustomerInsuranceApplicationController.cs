using Insurance.Application.Service.Interface;
using Insurance.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProcess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerInsuranceApplicationController : ControllerBase
    {
        private ICustomerApplicationAppService _customerApplicationAppService;
        public CustomerInsuranceApplicationController(ICustomerApplicationAppService customerApplicationAppService)
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
        [HttpGet("GetInsuranceCompanies")]
        public async Task<IEnumerable<InsuranceCompanyDto>> GetInsuranceCompanies()
        {
            return await _customerApplicationAppService.GetInsuranceCompaniesListAsync();
        }

        [HttpGet("GetDiagnosesCodes")]
        public async Task<IEnumerable<DiagnosesCodeDto>> GetDiagnosesCodes()
        {
            return await _customerApplicationAppService.GetDiagnosesCodesListAsync();
        }

        [HttpGet("GetPrescribedItems")]
        public async Task<IEnumerable<PrescribedItemDto>> GetPrescribedItems()
        {
            return await _customerApplicationAppService.GetPrescribedItemsListAsync();
        }
    }
}

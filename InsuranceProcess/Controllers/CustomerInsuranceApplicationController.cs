using Insurance.Application.Dto;
using Insurance.Application.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProcess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerInsuranceApplicationController : ControllerBase
    {
        private readonly ICustomerApplicationAppService _customerApplicationAppService;
        private readonly ICustomerReportAppService _reportService;

        public CustomerInsuranceApplicationController(
            ICustomerApplicationAppService customerApplicationAppService,
            ICustomerReportAppService reportService)
        {
            _customerApplicationAppService = customerApplicationAppService;
            _reportService = reportService;
        }

        [HttpPost("SaveInsuranceForm")]
        public async Task<IActionResult> CreateCustomerInsuranceApplicationAsync([FromBody] CustomerApplicationDto applicationDto)
        {
            //use Gard Helper 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customerApplicationAppService.CreateCustomerInsuranceApplicationAsync(applicationDto);
            return Ok("Customer application created successfully.");
        }
     
        [HttpGet("GetInsuranceCompanies")]
        public async Task<IEnumerable<InsuranceCompanyDto>> GetInsuranceCompaniesAsync()
        {
            return await _customerApplicationAppService.GetInsuranceCompaniesListAsync();
        }

        [HttpGet("GetDiagnosesCodes")]
        public async Task<IEnumerable<DiagnosesCodeDto>> GetDiagnosesCodesAsync()
        {
            return await _customerApplicationAppService.GetDiagnosesCodesListAsync();
        }

        [HttpGet("GetPrescribedItems")]
        public async Task<IEnumerable<PrescribedItemDto>> GetPrescribedItemsAsync()
        {
            return await _customerApplicationAppService.GetPrescribedItemsListAsync();
        }

        [HttpGet("GetCustomerReport")]
        public async Task<List<CustomerReportDto>> GetCustomerReport()
        {
            return await _reportService.GenerateCustomerReportAsync();
        }
    }
}

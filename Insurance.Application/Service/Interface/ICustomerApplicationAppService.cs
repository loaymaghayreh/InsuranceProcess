using Insurance.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Service.Interface
{
    public interface ICustomerApplicationAppService
    {
        Task CreateCustomerInsuranceApplicationAsync(CustomerApplicationDto customerApplicationDto);
        Task<IEnumerable<InsuranceCompanyDto>> GetInsuranceCompaniesListAsync();
        Task<IEnumerable<DiagnosesCodeDto>> GetDiagnosesCodesListAsync();
        Task<IEnumerable<PrescribedItemDto>> GetPrescribedItemsListAsync();
    }
}

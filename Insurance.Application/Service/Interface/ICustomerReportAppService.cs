using Insurance.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Service.Interface
{
    public interface ICustomerReportAppService
    {
        Task<List<CustomerReportDto>> GenerateCustomerReportAsync();
    }
}

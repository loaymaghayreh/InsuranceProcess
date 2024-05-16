using Insurance.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Service.Interface
{
    public interface IInsuranceAppService
    {
        public Task CreateCustomerInsuranceApplication(CustomerApplicationDto customerApplicationDto);
    }
}

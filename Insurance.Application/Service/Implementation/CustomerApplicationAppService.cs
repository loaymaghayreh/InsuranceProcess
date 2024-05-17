using AutoMapper;
using Insurance.Application.Service.Interface;
using Insurance.Domain.Dto;
using Insurance.Domain.Interface;
using Insurance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Service.Implementation
{
    public class CustomerApplicationAppService : ICustomerApplicationAppService
    {
        private ICustomerApplicationRepository _insuranceRepository;
        private readonly IMapper _mapper;
        public CustomerApplicationAppService(ICustomerApplicationRepository insuranceRepository, IMapper mapper)
        {
            _insuranceRepository = insuranceRepository;
            _mapper = mapper;
        }

        public async Task CreateCustomerInsuranceApplicationAsync(CustomerApplicationDto customerApplicationDto)
        {

            var customerApplication = _mapper.Map<CustomerApplication>(customerApplicationDto);

            await _insuranceRepository.AddAsync(customerApplication);

        }
    }
}

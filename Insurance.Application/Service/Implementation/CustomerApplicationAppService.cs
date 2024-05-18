using AutoMapper;
using Insurance.Application.Dto;
using Insurance.Application.Service.Interface;
using Insurance.Domain.Interface;
using Insurance.Domain.Model;
using Insurance.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Service.Implementation
{
    public class CustomerApplicationAppService : ICustomerApplicationAppService
    {
        private readonly IBaseRepository<CustomerApplication> _insuranceApplicationRepository;
        private readonly IBaseRepository<InsuranceCompany> _companiesRepository;
        private readonly IBaseRepository<DiagnosesCode> _diagnosesCodeRepository;
        private readonly IBaseRepository<PrescribedItem> _prescribedItemRepository;
        private readonly IMapper _mapper;
        public CustomerApplicationAppService(
            IBaseRepository<CustomerApplication> insuranceApplicationRepository,
            IBaseRepository<InsuranceCompany> companiesRepository,
            IBaseRepository<DiagnosesCode> diagnosesCodeRepository,
            IBaseRepository<PrescribedItem> prescribedItemRepository,
            IMapper mapper)
        {
            _insuranceApplicationRepository = insuranceApplicationRepository;
            _companiesRepository = companiesRepository;
            _diagnosesCodeRepository = diagnosesCodeRepository;
            _prescribedItemRepository = prescribedItemRepository;
            _mapper = mapper;
        }

        public async Task CreateCustomerInsuranceApplicationAsync(CustomerApplicationDto customerApplicationDto)
        {
            var customerApplication = _mapper.Map<CustomerApplication>(customerApplicationDto);

            await _insuranceApplicationRepository.AddAsync(customerApplication);
        }

        public async Task<IEnumerable<InsuranceCompanyDto>> GetInsuranceCompaniesListAsync()
        {
            var insuranceCompanies = await _companiesRepository.GetAllForReadingAsync();
            return _mapper.Map<List<InsuranceCompanyDto>>(insuranceCompanies);        
        }

        public async Task<IEnumerable<DiagnosesCodeDto>> GetDiagnosesCodesListAsync()
        {
            var diagnosesCodes = await _diagnosesCodeRepository.GetAllForReadingAsync();
            return _mapper.Map<List<DiagnosesCodeDto>>(diagnosesCodes);
        }

        public async Task<IEnumerable<PrescribedItemDto>> GetPrescribedItemsListAsync()
        {
            var prescribedItems = await _prescribedItemRepository.GetAllForReadingAsync();
            return _mapper.Map<List<PrescribedItemDto>>(prescribedItems);
        }
    }
}

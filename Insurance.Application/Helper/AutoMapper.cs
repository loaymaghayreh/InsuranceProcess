using AutoMapper;
using Insurance.Domain.Dto;
using Insurance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerApplication, CustomerApplicationDto>()
           .ForMember(dest => dest.DiagnosesCodes, opt => opt.MapFrom(src => src.CustomerApplicationDiagnosesCodes.Select(x => x.DiagnosesCode)))
           .ForMember(dest => dest.PrescribedItems, opt => opt.MapFrom(src => src.CustomerApplicationPrescribedItems.Select(x => x.PrescribedItemId)))
           .ReverseMap()
           .ForMember(dest => dest.CustomerApplicationDiagnosesCodes, opt => opt.MapFrom(src => src.DiagnosesCodes.Select(code => new CustomerApplicationDiagnosesCode { DiagnosesCodeId = code })))
           .ForMember(dest => dest.CustomerApplicationPrescribedItems, opt => opt.MapFrom(src => src.PrescribedItems.Select(item => new CustomerApplicationPrescribedItem { PrescribedItemId = item })));

            CreateMap<InsuranceCompany, InsuranceCompanyDto>().ReverseMap();
            CreateMap<PrescribedItem, PrescribedItemDto>().ReverseMap();
            CreateMap<DiagnosesCode, DiagnosesCodeDto>().ReverseMap();

        }
    }
}

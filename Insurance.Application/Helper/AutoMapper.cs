using AutoMapper;
using Insurance.Application.Dto;
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
            CreateMap<PrescriptionAttachment, PrescriptionAttachmentDto>()
                .ReverseMap()
                .ForMember(dest => dest.FileContent, opt => opt.MapFrom(src => ConvertFromBase64(src.FileContent)));

        }

        private static byte[] ConvertFromBase64(string base64Data)
        {
            // Find the comma following the base64, prefix
            int base64Start = base64Data.IndexOf("base64,") + 7; // "+7" to skip "base64," itself

            if (base64Start > 6) // Make sure "base64," was found
            {
                string base64String = base64Data.Substring(base64Start);
                return Convert.FromBase64String(base64String);
            }

            throw new ArgumentException("String does not contain a base64 section.");
        }
    }
}

using Insurance.Application.Dto;
using Insurance.Application.Service.Interface;
using Insurance.Domain.Model;
using Insurance.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Service.Implementation
{
    public class CustomerReportAppService : ICustomerReportAppService
    {
        private readonly AppDbContext _context;

        public CustomerReportAppService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerReportDto>> GenerateCustomerReportAsync()
        {
            var query = from customerApplication in _context.CustomerApplications
                        select new CustomerReportDto
                        {
                            NationalID = customerApplication.NationalId,
                            CustomerName = customerApplication.CustomerName,
                            DateOfBirth = customerApplication.DateOfBirth,
                            InsuranceCompany = customerApplication.InsuranceCompany.Name,
                            DiagnosesCodes = (from diagnosesCode in customerApplication.CustomerApplicationDiagnosesCodes
                                              select diagnosesCode.DiagnosesCode.Code).ToList(),

                            TotalItemCount = customerApplication.CustomerApplicationPrescribedItems.Count,
                            TotalItemQuantity = customerApplication.CustomerApplicationPrescribedItems.Sum(capi => capi.PrescribedItem.Quantity),
                            TotalPrice = customerApplication.CustomerApplicationPrescribedItems.Sum(capi => capi.PrescribedItem.Price * capi.PrescribedItem.Quantity)
                        };

            var result = await query.AsNoTracking().ToListAsync();

            return result;
        }
    }
}

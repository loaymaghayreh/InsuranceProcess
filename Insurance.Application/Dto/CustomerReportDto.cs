using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Dto
{
    public class CustomerReportDto
    {
        public string NationalID { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string InsuranceCompany { get; set; }
        public List<string> DiagnosesCodes { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalItemQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

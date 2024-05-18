using Insurance.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class CustomerApplication
    {
        [Key]
        public int CustomerApplicationId { get; set; }
        [Required]
        public string NationalId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PrescriptionAttachment? Attachment { get; set; }
        public virtual ICollection<CustomerApplicationDiagnosesCode> CustomerApplicationDiagnosesCodes { get; set; } = new List<CustomerApplicationDiagnosesCode>();
        public virtual ICollection<CustomerApplicationPrescribedItem> CustomerApplicationPrescribedItems { get; set; } = new List<CustomerApplicationPrescribedItem>();
    }
}
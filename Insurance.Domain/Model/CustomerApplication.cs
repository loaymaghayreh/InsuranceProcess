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
        [Required]
        public string CustomerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int InsuranceCompanyId { get; set; }
        public PrescriptionAttachment? Attachment { get; set; }
        public virtual ICollection<CustomerApplicationDiagnosesCode> CustomerApplicationDiagnosesCodes { get; set; } = new List<CustomerApplicationDiagnosesCode>();
        public virtual ICollection<CustomerApplicationPrescribedItem> CustomerApplicationPrescribedItems { get; set; } = new List<CustomerApplicationPrescribedItem>();
/*
        public CustomerApplication(string nationalId, string CustomerName ,DateTime dateOfBirth ,int insuranceCompanyId , List<int> diagnosesCodesId, List<int> prescribedItem, PrescriptionAttachment? attachment = null)
        {
            
        }
        public static CustomerApplication CreateAsync(string nationalId, string CustomerName, DateTime dateOfBirth, int insuranceCompanyId, List<int> diagnosesCodesId, List<int> prescribedItem, PrescriptionAttachment? attachment = null)
        {
            //validate Data

            return new CustomerApplication();
        }*/
    }
}
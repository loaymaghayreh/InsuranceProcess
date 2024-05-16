using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class CustomerApplication
    {
        [Key]
        public int NationalID { get; set; }
        public string CustomerName { get; set; }
        public int InsuranceCompanyId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<DiagnosesCode> DiagnosesCodes { get; set; }
        public PrescriptionAttachment Attachment { get; set; }
        public List<PrescribedItem> PrescribedItems { get; set; }
    }
}

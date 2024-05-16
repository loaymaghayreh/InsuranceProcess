using Insurance.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Dto
{
    public class CustomerApplicationDto
    {
        [Required]
        [RegularExpression("^[12][0-9]{9}$", ErrorMessage = "Customer National ID must be 10 characters long and start with '1' or '2'.")]
        public string CustomerNationalID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public int InsuranceCompanyId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> DiagnosesCodes { get; set; }
        public PrescriptionAttachment Attachment { get; set; }
        public List<PrescribedItemDto> PrescribedItems { get; set; }
    }
}

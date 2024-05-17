using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class DiagnosesCode
    {
        [Key]
        public int DiagnosesCodeId { get; set; }
        public string Code { get; set; }
        public string Discription { get; set; }
        public virtual ICollection<CustomerApplicationDiagnosesCode> CustomerApplicationDiagnosesCodes { get; set; } = new List<CustomerApplicationDiagnosesCode>();
    }
}

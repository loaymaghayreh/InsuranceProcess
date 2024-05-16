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
        public Guid Code { get; set; }
        public string Discription { get; set; }
    }
}

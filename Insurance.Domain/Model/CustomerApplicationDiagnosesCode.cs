using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class CustomerApplicationDiagnosesCode
    {
        public int CustomerApplicationId { get; set; }
        public CustomerApplication CustomerApplication { get; set; }

        public int DiagnosesCodeId { get; set; }
        public DiagnosesCode DiagnosesCode { get; set; }
    }
}

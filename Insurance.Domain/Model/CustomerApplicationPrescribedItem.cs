using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class CustomerApplicationPrescribedItem
    {
        public int CustomerApplicationId { get; set; }
        public CustomerApplication CustomerApplication { get; set; }

        public int PrescribedItemId { get; set; }
        public PrescribedItem PrescribedItem { get; set; }
    }
}

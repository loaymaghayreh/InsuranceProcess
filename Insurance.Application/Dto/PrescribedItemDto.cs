using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Dto
{
    public class PrescribedItemDto
    {
        public int Id { get; set; }
        public string ItemNumber { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Dosage { get; set; }
    }
}

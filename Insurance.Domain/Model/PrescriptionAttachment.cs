using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class PrescriptionAttachment
    {
        [Key]
        public int AttachmentId { get; set; }
        public int NationalID { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}

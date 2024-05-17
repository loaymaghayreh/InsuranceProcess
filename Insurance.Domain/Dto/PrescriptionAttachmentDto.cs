using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Dto
{
    public class PrescriptionAttachmentDto
    {
        public string? FileName { get; set; }
        public byte[]? FileContent { get; set; }
    }
}

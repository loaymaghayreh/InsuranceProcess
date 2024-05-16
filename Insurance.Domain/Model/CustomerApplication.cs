﻿using System;
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
        [Required]
        public string CustomerNationalID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public int InsuranceCompanyId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PrescriptionAttachment Attachment { get; set; }
        public virtual ICollection<PrescribedItem> PrescribedItems { get; set; } = new List<PrescribedItem>();
        public virtual ICollection<DiagnosesCode> DiagnosesCodes { get; set; } = new List<DiagnosesCode>();
    }
}

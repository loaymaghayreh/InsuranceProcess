﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class InsuranceCompany
    {
        [Key]
        public int InsuranceCompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}

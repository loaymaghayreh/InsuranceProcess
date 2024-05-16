using Insurance.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options) : base(options)
        {

        }

        public DbSet<CustomerApplication> customerApplications { get; set; }
        public DbSet<InsuranceCompany> insuranceCompanies { get; set; }
        public DbSet<DiagnosesCode> diagnosesCodes { get; set; }
        public DbSet<PrescriptionAttachment> prescriptionAttachments { get; set; }
        public DbSet<PrescribedItem> prescribedItems { get; set; }
    }
}

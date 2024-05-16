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

        public DbSet<CustomerApplication> CustomerApplications { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<DiagnosesCode> DiagnosesCodes { get; set; }
        public DbSet<PrescriptionAttachment> PrescriptionAttachments { get; set; }
        public DbSet<PrescribedItem> PrescribedItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerApplication>()
                .HasMany(c => c.DiagnosesCodes)
                .WithMany(d => d.CustomerApplications)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerApplicationDiagnosisCode", 
                    j => j.HasOne<DiagnosesCode>().WithMany().HasForeignKey("DiagnosesCodeId"),
                    j => j.HasOne<CustomerApplication>().WithMany().HasForeignKey("CustomerNationalID"),
                    j =>
                    {
                        j.HasKey("CustomerNationalID", "DiagnosesCodeId");
                    });

            modelBuilder.Entity<CustomerApplication>()
                .HasMany(c => c.PrescribedItems)
                .WithMany(p => p.CustomerApplications)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerApplicationPrescribedItem", 
                    j => j.HasOne<PrescribedItem>().WithMany().HasForeignKey("PrescribedItemId"),
                    j => j.HasOne<CustomerApplication>().WithMany().HasForeignKey("CustomerNationalID"),
                    j =>
                    {
                        j.HasKey("CustomerNationalID", "PrescribedItemId"); 
                    });
        }
    }
}

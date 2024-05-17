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

            //DiagnosesCode
            modelBuilder.Entity<CustomerApplicationDiagnosesCode>()
                .HasKey(c => new { c.CustomerApplicationId, c.DiagnosesCodeId });

            modelBuilder.Entity<CustomerApplicationDiagnosesCode>()
                .HasOne(c => c.CustomerApplication)
                .WithMany(ca => ca.CustomerApplicationDiagnosesCodes)
                .HasForeignKey(c => c.CustomerApplicationId);

            modelBuilder.Entity<CustomerApplicationDiagnosesCode>()
                .HasOne(c => c.DiagnosesCode)
                .WithMany(dc => dc.CustomerApplicationDiagnosesCodes)
                .HasForeignKey(c => c.DiagnosesCodeId);


            //PrescribedItem
            modelBuilder.Entity<CustomerApplicationPrescribedItem>()
                .HasKey(c => new { c.CustomerApplicationId, c.PrescribedItemId });

            modelBuilder.Entity<CustomerApplicationPrescribedItem>()
                .HasOne(c => c.CustomerApplication)
                .WithMany(ca => ca.CustomerApplicationPrescribedItems)
                .HasForeignKey(c => c.CustomerApplicationId);

            modelBuilder.Entity<CustomerApplicationPrescribedItem>()
                .HasOne(c => c.PrescribedItem)
                .WithMany(pi => pi.CustomerApplicationPrescribedItems)
                .HasForeignKey(c => c.PrescribedItemId);


            //Attachment
            modelBuilder.Entity<CustomerApplication>()
                .HasOne(e => e.Attachment)
                .WithOne()
                .HasForeignKey<PrescriptionAttachment>(e => e.AttachmentId)
                .IsRequired(false);
        }
    }
}

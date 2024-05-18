﻿// <auto-generated />
using System;
using Insurance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Insurance.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplication", b =>
                {
                    b.Property<int>("CustomerApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerApplicationId"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsuranceCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerApplicationId");

                    b.HasIndex("InsuranceCompanyId");

                    b.ToTable("CustomerApplications");
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplicationDiagnosesCode", b =>
                {
                    b.Property<int>("CustomerApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("DiagnosesCodeId")
                        .HasColumnType("int");

                    b.HasKey("CustomerApplicationId", "DiagnosesCodeId");

                    b.HasIndex("DiagnosesCodeId");

                    b.ToTable("CustomerApplicationDiagnosesCode");
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplicationPrescribedItem", b =>
                {
                    b.Property<int>("CustomerApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("PrescribedItemId")
                        .HasColumnType("int");

                    b.HasKey("CustomerApplicationId", "PrescribedItemId");

                    b.HasIndex("PrescribedItemId");

                    b.ToTable("CustomerApplicationPrescribedItem");
                });

            modelBuilder.Entity("Insurance.Domain.Model.DiagnosesCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiagnosesCodes");
                });

            modelBuilder.Entity("Insurance.Domain.Model.InsuranceCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InsuranceCompanies");
                });

            modelBuilder.Entity("Insurance.Domain.Model.PrescribedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PrescribedItems");
                });

            modelBuilder.Entity("Insurance.Domain.Model.PrescriptionAttachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .HasColumnType("int");

                    b.Property<byte[]>("FileContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttachmentId");

                    b.ToTable("PrescriptionAttachments");
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplication", b =>
                {
                    b.HasOne("Insurance.Domain.Model.InsuranceCompany", "InsuranceCompany")
                        .WithMany()
                        .HasForeignKey("InsuranceCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsuranceCompany");
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplicationDiagnosesCode", b =>
                {
                    b.HasOne("Insurance.Domain.Model.CustomerApplication", "CustomerApplication")
                        .WithMany("CustomerApplicationDiagnosesCodes")
                        .HasForeignKey("CustomerApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insurance.Domain.Model.DiagnosesCode", "DiagnosesCode")
                        .WithMany("CustomerApplicationDiagnosesCodes")
                        .HasForeignKey("DiagnosesCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerApplication");

                    b.Navigation("DiagnosesCode");
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplicationPrescribedItem", b =>
                {
                    b.HasOne("Insurance.Domain.Model.CustomerApplication", "CustomerApplication")
                        .WithMany("CustomerApplicationPrescribedItems")
                        .HasForeignKey("CustomerApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insurance.Domain.Model.PrescribedItem", "PrescribedItem")
                        .WithMany("CustomerApplicationPrescribedItems")
                        .HasForeignKey("PrescribedItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerApplication");

                    b.Navigation("PrescribedItem");
                });

            modelBuilder.Entity("Insurance.Domain.Model.PrescriptionAttachment", b =>
                {
                    b.HasOne("Insurance.Domain.Model.CustomerApplication", null)
                        .WithOne("Attachment")
                        .HasForeignKey("Insurance.Domain.Model.PrescriptionAttachment", "AttachmentId");
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplication", b =>
                {
                    b.Navigation("Attachment");

                    b.Navigation("CustomerApplicationDiagnosesCodes");

                    b.Navigation("CustomerApplicationPrescribedItems");
                });

            modelBuilder.Entity("Insurance.Domain.Model.DiagnosesCode", b =>
                {
                    b.Navigation("CustomerApplicationDiagnosesCodes");
                });

            modelBuilder.Entity("Insurance.Domain.Model.PrescribedItem", b =>
                {
                    b.Navigation("CustomerApplicationPrescribedItems");
                });
#pragma warning restore 612, 618
        }
    }
}

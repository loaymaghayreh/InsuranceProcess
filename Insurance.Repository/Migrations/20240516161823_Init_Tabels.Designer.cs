﻿// <auto-generated />
using System;
using Insurance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Insurance.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240516161823_Init_Tabels")]
    partial class InitTabels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerApplicationDiagnosisCode", b =>
                {
                    b.Property<string>("CustomerNationalID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DiagnosesCodeId")
                        .HasColumnType("int");

                    b.HasKey("CustomerNationalID", "DiagnosesCodeId");

                    b.HasIndex("DiagnosesCodeId");

                    b.ToTable("CustomerApplicationDiagnosisCode");
                });

            modelBuilder.Entity("CustomerApplicationPrescribedItem", b =>
                {
                    b.Property<string>("CustomerNationalID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PrescribedItemId")
                        .HasColumnType("int");

                    b.HasKey("CustomerNationalID", "PrescribedItemId");

                    b.HasIndex("PrescribedItemId");

                    b.ToTable("CustomerApplicationPrescribedItem");
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplication", b =>
                {
                    b.Property<string>("CustomerNationalID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AttachmentId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsuranceCompanyId")
                        .HasColumnType("int");

                    b.HasKey("CustomerNationalID");

                    b.HasIndex("AttachmentId");

                    b.ToTable("CustomerApplications");
                });

            modelBuilder.Entity("Insurance.Domain.Model.DiagnosesCode", b =>
                {
                    b.Property<int>("DiagnosesCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiagnosesCodeId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiagnosesCodeId");

                    b.ToTable("DiagnosesCodes");
                });

            modelBuilder.Entity("Insurance.Domain.Model.InsuranceCompany", b =>
                {
                    b.Property<int>("InsuranceCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsuranceCompanyId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InsuranceCompanyId");

                    b.ToTable("InsuranceCompanies");
                });

            modelBuilder.Entity("Insurance.Domain.Model.PrescribedItem", b =>
                {
                    b.Property<int>("PrescribedItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescribedItemId"));

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

                    b.HasKey("PrescribedItemId");

                    b.ToTable("PrescribedItems");
                });

            modelBuilder.Entity("Insurance.Domain.Model.PrescriptionAttachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttachmentId"));

                    b.Property<byte[]>("FileContent")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttachmentId");

                    b.ToTable("PrescriptionAttachments");
                });

            modelBuilder.Entity("CustomerApplicationDiagnosisCode", b =>
                {
                    b.HasOne("Insurance.Domain.Model.CustomerApplication", null)
                        .WithMany()
                        .HasForeignKey("CustomerNationalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insurance.Domain.Model.DiagnosesCode", null)
                        .WithMany()
                        .HasForeignKey("DiagnosesCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerApplicationPrescribedItem", b =>
                {
                    b.HasOne("Insurance.Domain.Model.CustomerApplication", null)
                        .WithMany()
                        .HasForeignKey("CustomerNationalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insurance.Domain.Model.PrescribedItem", null)
                        .WithMany()
                        .HasForeignKey("PrescribedItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplication", b =>
                {
                    b.HasOne("Insurance.Domain.Model.PrescriptionAttachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");
                });
#pragma warning restore 612, 618
        }
    }
}
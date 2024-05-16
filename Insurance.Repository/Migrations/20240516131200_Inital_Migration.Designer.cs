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
    [Migration("20240516131200_Inital_Migration")]
    partial class InitalMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplication", b =>
                {
                    b.Property<int>("NationalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NationalID"));

                    b.Property<int>("AttachmentId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsuranceCompanyId")
                        .HasColumnType("int");

                    b.HasKey("NationalID");

                    b.HasIndex("AttachmentId");

                    b.ToTable("customerApplications");
                });

            modelBuilder.Entity("Insurance.Domain.Model.DiagnosesCode", b =>
                {
                    b.Property<Guid>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CustomerApplicationNationalID")
                        .HasColumnType("int");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.HasIndex("CustomerApplicationNationalID");

                    b.ToTable("diagnosesCodes");
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

                    b.ToTable("insuranceCompanies");
                });

            modelBuilder.Entity("Insurance.Domain.Model.PrescribedItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<int?>("CustomerApplicationNationalID")
                        .HasColumnType("int");

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

                    b.HasKey("ItemId");

                    b.HasIndex("CustomerApplicationNationalID");

                    b.ToTable("prescribedItems");
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

                    b.Property<int>("NationalID")
                        .HasColumnType("int");

                    b.HasKey("AttachmentId");

                    b.ToTable("prescriptionAttachments");
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

            modelBuilder.Entity("Insurance.Domain.Model.DiagnosesCode", b =>
                {
                    b.HasOne("Insurance.Domain.Model.CustomerApplication", null)
                        .WithMany("DiagnosesCodes")
                        .HasForeignKey("CustomerApplicationNationalID");
                });

            modelBuilder.Entity("Insurance.Domain.Model.PrescribedItem", b =>
                {
                    b.HasOne("Insurance.Domain.Model.CustomerApplication", null)
                        .WithMany("PrescribedItems")
                        .HasForeignKey("CustomerApplicationNationalID");
                });

            modelBuilder.Entity("Insurance.Domain.Model.CustomerApplication", b =>
                {
                    b.Navigation("DiagnosesCodes");

                    b.Navigation("PrescribedItems");
                });
#pragma warning restore 612, 618
        }
    }
}

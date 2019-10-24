﻿// <auto-generated />
using EPrescription.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EPrescription.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191024165238_DoctorModel")]
    partial class DoctorModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EPrescription.Models.Company", b =>
                {
                    b.Property<string>("companyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("companyAddress")
                        .IsRequired();

                    b.Property<string>("companyEmail")
                        .IsRequired();

                    b.Property<string>("companyLicence")
                        .IsRequired();

                    b.Property<string>("companyName")
                        .IsRequired();

                    b.Property<string>("companyPassword")
                        .IsRequired();

                    b.HasKey("companyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EPrescription.Models.Doctor", b =>
                {
                    b.Property<string>("doctorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("doctorDesignation")
                        .IsRequired();

                    b.Property<string>("doctorName")
                        .IsRequired();

                    b.Property<string>("doctorPassword")
                        .IsRequired();

                    b.Property<string>("doctorPhoneNumber")
                        .IsRequired();

                    b.Property<string>("doctorSpecializedArea")
                        .IsRequired();

                    b.HasKey("doctorId");

                    b.ToTable("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}

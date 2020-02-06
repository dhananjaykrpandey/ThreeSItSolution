﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThreeSItSolution.Models;

namespace ThreeSItSolution.Migrations
{
    [DbContext(typeof(Db3SItSoultion))]
    partial class Db3SItSoultionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThreeSItSolution.Models.MContactUs", b =>
                {
                    b.Property<int>("IID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(8000);

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DCreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IID");

                    b.ToTable("MContactUs");
                });

            modelBuilder.Entity("ThreeSItSolution.Models.MEnquiry", b =>
                {
                    b.Property<int>("IID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("cAcademic")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("cAddress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<string>("cCareerBackground")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("cCompnay")
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("cCurrentOccupation")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("cEmailId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasMaxLength(30);

                    b.Property<string>("cFullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasMaxLength(30);

                    b.Property<string>("cGenger")
                        .IsRequired()
                        .HasColumnType("VARCHAR(1)")
                        .HasMaxLength(1);

                    b.Property<string>("cGuradian")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("cMobileNo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasMaxLength(30);

                    b.Property<string>("cPhoneNo")
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("cReason")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("cRemakrs")
                        .HasColumnType("VARCHAR(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("cSchaool")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("cSourceOfInfo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("dDob")
                        .HasColumnType("DateTime");

                    b.HasKey("IID");

                    b.ToTable("MEnquiry");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Lap2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lap2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lap2.Models.Address", b =>
                {
                    b.Property<int>("Addr_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Addr_ID"));

                    b.Property<string>("Home_addr")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Office_addr")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Addr_ID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Lap2.Models.Client", b =>
                {
                    b.Property<string>("clientName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Address_ID")
                        .HasColumnType("int");

                    b.Property<string>("phoneNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("clientName");

                    b.HasIndex("Address_ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Lap2.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Lap2.Models.NhanVien", b =>
                {
                    b.Property<string>("MANV")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("DCHI")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("HONV")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<float>("LUONG")
                        .HasColumnType("real");

                    b.Property<string>("MA_NQL")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<DateTime>("NGAYSINH")
                        .HasColumnType("datetime2");

                    b.Property<string>("PHAI")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("PHG")
                        .HasColumnType("int");

                    b.Property<string>("TENLOT")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TENNV")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("MANV");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("Lap2.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Lap2.Models.PersonCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("Current")
                        .HasColumnType("bit");

                    b.Property<int>("FromYear")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ToYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonCompanies");
                });

            modelBuilder.Entity("Lap2.Models.ThanNhan", b =>
                {
                    b.Property<string>("MA_NVIEN")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnOrder(0);

                    b.Property<string>("TENTN")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("NGSINH")
                        .HasColumnType("datetime2");

                    b.Property<string>("PHAI")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("QUANHE")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("MA_NVIEN", "TENTN");

                    b.ToTable("ThanNhans");
                });

            modelBuilder.Entity("Lap2.Models.Client", b =>
                {
                    b.HasOne("Lap2.Models.Address", "Address")
                        .WithMany("Clients")
                        .HasForeignKey("Address_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Lap2.Models.PersonCompany", b =>
                {
                    b.HasOne("Lap2.Models.Company", "Company")
                        .WithMany("PersonCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lap2.Models.Person", "Person")
                        .WithMany("PersonCompanies")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Lap2.Models.ThanNhan", b =>
                {
                    b.HasOne("Lap2.Models.NhanVien", "NhanVien")
                        .WithMany("ThanNhans")
                        .HasForeignKey("MA_NVIEN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Lap2.Models.Address", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Lap2.Models.Company", b =>
                {
                    b.Navigation("PersonCompanies");
                });

            modelBuilder.Entity("Lap2.Models.NhanVien", b =>
                {
                    b.Navigation("ThanNhans");
                });

            modelBuilder.Entity("Lap2.Models.Person", b =>
                {
                    b.Navigation("PersonCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using FCI.AlzheimerDetection.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FCI.AlzheimerDetection.DAL.Migrations
{
    [DbContext(typeof(AlzheimerDetectionDbContext))]
    partial class AlzheimerDetectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.AddRelative", b =>
                {
                    b.Property<int>("RelativeId")
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("RelativeId", "AdminId", "PatientId");

                    b.HasIndex("AdminId");

                    b.HasIndex("PatientId");

                    b.ToTable("AddRelative");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.AdminMRI", b =>
                {
                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("MRIId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AdminId", "MRIId");

                    b.HasIndex("MRIId");

                    b.ToTable("AdminMRI");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.AppFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Medicines", (string)null);
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.NormalUserMRI", b =>
                {
                    b.Property<int>("NormalUserId")
                        .HasColumnType("int");

                    b.Property<int>("MRIId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("NormalUserId", "MRIId");

                    b.HasIndex("MRIId");

                    b.ToTable("NormalUserMRI");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.RelativeMedicine", b =>
                {
                    b.Property<int>("RelativeId")
                        .HasColumnType("int");

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Expired")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SetedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("RelativeId", "MedicineId");

                    b.HasIndex("MedicineId");

                    b.ToTable("RelativeMedicine");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Image", b =>
                {
                    b.HasBaseType("FCI.AlzheimerDetection.DAL.Models.AppFile");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasIndex("PatientId")
                        .IsUnique()
                        .HasFilter("[PatientId] IS NOT NULL");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.MRI", b =>
                {
                    b.HasBaseType("FCI.AlzheimerDetection.DAL.Models.AppFile");

                    b.ToTable("MRIs");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Report", b =>
                {
                    b.HasBaseType("FCI.AlzheimerDetection.DAL.Models.AppFile");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.HasIndex("AdminId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", b =>
                {
                    b.HasBaseType("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.NormalUser", b =>
                {
                    b.HasBaseType("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser");

                    b.ToTable("NormalUsers", (string)null);
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.Relative", b =>
                {
                    b.HasBaseType("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RelationshipDegree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.ToTable("Relatives", (string)null);
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.AddRelative", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", "Admin")
                        .WithMany("AddRelatives")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Admin_AddRelatives");

                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Patient", "Patient")
                        .WithMany("AddRelatives")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Patient_AddRelatives");

                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.Relative", "Relative")
                        .WithMany("AddRelatives")
                        .HasForeignKey("RelativeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Relative_AddRelatives");

                    b.Navigation("Admin");

                    b.Navigation("Patient");

                    b.Navigation("Relative");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.AdminMRI", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", "Admin")
                        .WithMany("AdminMRIs")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Admin_MRIs");

                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.MRI", "MRI")
                        .WithMany("AdminMRIs")
                        .HasForeignKey("MRIId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("MRI");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Medicine", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", "Admin")
                        .WithMany("Medicines")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Admin_Medicines");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.NormalUserMRI", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.MRI", "MRI")
                        .WithMany("NormalUserMRIs")
                        .HasForeignKey("MRIId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.NormalUser", "NormalUser")
                        .WithMany("NormalUserMRIs")
                        .HasForeignKey("NormalUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_NormalUser_NormalUserMRIs");

                    b.Navigation("MRI");

                    b.Navigation("NormalUser");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Patient", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", "Admin")
                        .WithMany("Patients")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Admin_Patients");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.RelativeMedicine", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Medicine", "Medicine")
                        .WithMany("RelativeMedicine")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Medicine_Relatives");

                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.Relative", "Relative")
                        .WithMany("RelativeMedicine")
                        .HasForeignKey("RelativeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Relative_Medicines");

                    b.Navigation("Medicine");

                    b.Navigation("Relative");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Image", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.AppFile", null)
                        .WithOne()
                        .HasForeignKey("FCI.AlzheimerDetection.DAL.Models.Image", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Patient", "Patient")
                        .WithOne("Image")
                        .HasForeignKey("FCI.AlzheimerDetection.DAL.Models.Image", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Patient_Image");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.MRI", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.AppFile", null)
                        .WithOne()
                        .HasForeignKey("FCI.AlzheimerDetection.DAL.Models.MRI", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Report", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", "Admin")
                        .WithMany("Reports")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Admin_Reports");

                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.AppFile", null)
                        .WithOne()
                        .HasForeignKey("FCI.AlzheimerDetection.DAL.Models.Report", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.NormalUser", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("FCI.AlzheimerDetection.DAL.Models.Identity.NormalUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.Relative", b =>
                {
                    b.HasOne("FCI.AlzheimerDetection.DAL.Models.Identity.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("FCI.AlzheimerDetection.DAL.Models.Identity.Relative", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Medicine", b =>
                {
                    b.Navigation("RelativeMedicine");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Patient", b =>
                {
                    b.Navigation("AddRelatives");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.MRI", b =>
                {
                    b.Navigation("AdminMRIs");

                    b.Navigation("NormalUserMRIs");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.Admin", b =>
                {
                    b.Navigation("AddRelatives");

                    b.Navigation("AdminMRIs");

                    b.Navigation("Medicines");

                    b.Navigation("Patients");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.NormalUser", b =>
                {
                    b.Navigation("NormalUserMRIs");
                });

            modelBuilder.Entity("FCI.AlzheimerDetection.DAL.Models.Identity.Relative", b =>
                {
                    b.Navigation("AddRelatives");

                    b.Navigation("RelativeMedicine");
                });
#pragma warning restore 612, 618
        }
    }
}

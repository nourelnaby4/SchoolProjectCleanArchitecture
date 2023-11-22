﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School.Infrastructure.Data;

#nullable disable

namespace School.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231120211456_rebuild entities")]
    partial class rebuildentities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("School.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.ToTable("departments");
                });

            modelBuilder.Entity("School.Data.Entities.DepartmentSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("departmentSubjects");
                });

            modelBuilder.Entity("School.Data.Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SupervisorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupervisorId");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("School.Data.Entities.InstructorSubject", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("instructorSubjects");
                });

            modelBuilder.Entity("School.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("School.Data.Entities.StudentSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("studentSubjects");
                });

            modelBuilder.Entity("School.Data.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("School.Data.Entities.Department", b =>
                {
                    b.HasOne("School.Data.Entities.Instructor", "Manager")
                        .WithOne("DepartmentManage")
                        .HasForeignKey("School.Data.Entities.Department", "ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("School.Data.Entities.DepartmentSubject", b =>
                {
                    b.HasOne("School.Data.Entities.Department", "Department")
                        .WithMany("DepartmentsSubjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Data.Entities.Subject", "Subject")
                        .WithMany("DepartmentsSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School.Data.Entities.Instructor", b =>
                {
                    b.HasOne("School.Data.Entities.Instructor", "Suprvisor")
                        .WithMany("Instructors")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Suprvisor");
                });

            modelBuilder.Entity("School.Data.Entities.InstructorSubject", b =>
                {
                    b.HasOne("School.Data.Entities.Instructor", "Instructor")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Data.Entities.Subject", "Subject")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School.Data.Entities.Student", b =>
                {
                    b.HasOne("School.Data.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("School.Data.Entities.StudentSubject", b =>
                {
                    b.HasOne("School.Data.Entities.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Data.Entities.Subject", "Subject")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("School.Data.Entities.Department", b =>
                {
                    b.Navigation("DepartmentsSubjects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("School.Data.Entities.Instructor", b =>
                {
                    b.Navigation("DepartmentManage")
                        .IsRequired();

                    b.Navigation("InstructorSubjects");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("School.Data.Entities.Student", b =>
                {
                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("School.Data.Entities.Subject", b =>
                {
                    b.Navigation("DepartmentsSubjects");

                    b.Navigation("InstructorSubjects");

                    b.Navigation("StudentsSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BachelorManagement.DataLayer.Migrations
{
    [DbContext(typeof(BachelorManagementContext))]
    partial class BachelorManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int>("TeacherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.Property<string>("Interval");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Files");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.FileContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<int>("FileId");

                    b.HasKey("Id");

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.ToTable("FileContents");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FileId");

                    b.Property<double>("GradeValue");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Mean", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("FifthSemester");

                    b.Property<double>("FirstSemester");

                    b.Property<double>("FourthSemester");

                    b.Property<double>("SecondSemester");

                    b.Property<double>("SixthSemester");

                    b.Property<int>("StudentId");

                    b.Property<double>("ThirdSemester");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Means");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("SerialNumber");

                    b.Property<string>("StartYear");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.StudentContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<string>("Content");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentContents");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("NumberOfStudents");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.TeacherContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<string>("Content");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherContents");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SessionId");

                    b.Property<bool>("SpringSession");

                    b.Property<bool>("SummerSession");

                    b.Property<string>("YearValue");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Announcement", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithMany("Announcements")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Comment", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Consultation", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithOne("Consultation")
                        .HasForeignKey("BachelorManagement.DataLayer.Entities.Consultation", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.File", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Student", "Student")
                        .WithOne("File")
                        .HasForeignKey("BachelorManagement.DataLayer.Entities.File", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.FileContent", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.File", "File")
                        .WithOne("FileContent")
                        .HasForeignKey("BachelorManagement.DataLayer.Entities.FileContent", "FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Grade", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.File", "File")
                        .WithMany("Grades")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Mean", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Student", "Student")
                        .WithOne("Mean")
                        .HasForeignKey("BachelorManagement.DataLayer.Entities.Mean", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Session", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithMany("Sessions")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Student", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.StudentContent", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Comment", "Comment")
                        .WithMany("StudentContents")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BachelorManagement.DataLayer.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.TeacherContent", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Comment", "Comment")
                        .WithMany("TeacherContents")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Year", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Session", "Session")
                        .WithMany("Years")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

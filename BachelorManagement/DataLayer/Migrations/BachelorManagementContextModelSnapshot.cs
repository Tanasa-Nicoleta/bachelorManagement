﻿// <auto-generated />
using System;
using BachelorManagement.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BachelorManagement.DataLayer.Migrations
{
    [DbContext(typeof(BachelorManagementContext))]
    partial class BachelorManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview2-30571")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.BachelorTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("StudentId");

                    b.Property<int?>("TeacherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.HasIndex("TeacherId");

                    b.ToTable("BachelorThemes");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentContent");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("StudentId");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.CommentReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<string>("CommentReplyContent");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentReplies");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.Property<string>("Interval");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique()
                        .HasFilter("[TeacherId] IS NOT NULL");

                    b.ToTable("Consultations");
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

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.MeetingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<int?>("StudentId");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.HasIndex("TeacherId");

                    b.ToTable("MeetingRequests");
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

                    b.Property<bool>("Accepted");

                    b.Property<string>("Achievements");

                    b.Property<bool>("Denied");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("GitUrl");

                    b.Property<string>("LastName");

                    b.Property<bool>("Pending");

                    b.Property<string>("SerialNumber");

                    b.Property<string>("StartYear");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discipline");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<int>("NumberOfAvailableSpots");

                    b.Property<int>("NumberOfSpots");

                    b.Property<string>("Requirement");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<Guid>("Token");

                    b.Property<int>("UserType");

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

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.BachelorTheme", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Student", "Student")
                        .WithOne("StudentBachelorTheme")
                        .HasForeignKey("BachelorManagement.DataLayer.Entities.BachelorTheme", "StudentId");

                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithMany("BachelorThemes")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Comment", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Student", "Student")
                        .WithMany("Comments")
                        .HasForeignKey("StudentId");

                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.CommentReply", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Comment", "Comment")
                        .WithMany("CommentReplies")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Consultation", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithOne("Consultation")
                        .HasForeignKey("BachelorManagement.DataLayer.Entities.Consultation", "TeacherId");
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.Mean", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Student", "Student")
                        .WithOne("Mean")
                        .HasForeignKey("BachelorManagement.DataLayer.Entities.Mean", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BachelorManagement.DataLayer.Entities.MeetingRequest", b =>
                {
                    b.HasOne("BachelorManagement.DataLayer.Entities.Student", "Student")
                        .WithOne("MeetingRequest")
                        .HasForeignKey("BachelorManagement.DataLayer.Entities.MeetingRequest", "StudentId");

                    b.HasOne("BachelorManagement.DataLayer.Entities.Teacher", "Teacher")
                        .WithMany("MeetingRequests")
                        .HasForeignKey("TeacherId");
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

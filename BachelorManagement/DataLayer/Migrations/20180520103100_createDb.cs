﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BachelorManagement.DataLayer.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Teachers",
                table => new
                {
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NumberOfSpots = table.Column<int>(nullable: false),
                    NumberOfAvailableSpots = table.Column<int>(nullable: false),
                    Discipline = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table => { table.PrimaryKey("PK_Teachers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Sessions",
                table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        "FK_Sessions_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Students",
                table => new
                {
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    StartYear = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false),
                    Achievements = table.Column<string>(nullable: true),
                    GitUrl = table.Column<string>(nullable: true),
                    Accepted = table.Column<bool>(nullable: false),
                    Denied = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        "FK_Students_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Years",
                table => new
                {
                    YearValue = table.Column<string>(nullable: true),
                    SpringSession = table.Column<bool>(nullable: false),
                    SummerSession = table.Column<bool>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                    table.ForeignKey(
                        "FK_Years_Sessions_SessionId",
                        x => x.SessionId,
                        "Sessions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "BachelorThemes",
                table => new
                {
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BachelorThemes", x => x.Id);
                    table.ForeignKey(
                        "FK_BachelorThemes_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_BachelorThemes_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Comments",
                table => new
                {
                    StudentId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    CommentContent = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        "FK_Comments_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Comments_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Consultations",
                table => new
                {
                    Day = table.Column<int>(nullable: false),
                    Interval = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        "FK_Consultations_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Consultations_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Means",
                table => new
                {
                    FirstSemester = table.Column<double>(nullable: false),
                    SecondSemester = table.Column<double>(nullable: false),
                    ThirdSemester = table.Column<double>(nullable: false),
                    FourthSemester = table.Column<double>(nullable: false),
                    FifthSemester = table.Column<double>(nullable: false),
                    SixthSemester = table.Column<double>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Means", x => x.Id);
                    table.ForeignKey(
                        "FK_Means_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "MeetingRequest",
                table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    TeacherId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRequest", x => x.Id);
                    table.ForeignKey(
                        "FK_MeetingRequest_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_MeetingRequest_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "CommentReplies",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>(nullable: false),
                    CommentReplyContent = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReplies", x => x.Id);
                    table.ForeignKey(
                        "FK_CommentReplies_Comments_CommentId",
                        x => x.CommentId,
                        "Comments",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_BachelorThemes_StudentId",
                "BachelorThemes",
                "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_BachelorThemes_TeacherId",
                "BachelorThemes",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_CommentReplies_CommentId",
                "CommentReplies",
                "CommentId");

            migrationBuilder.CreateIndex(
                "IX_Comments_StudentId",
                "Comments",
                "StudentId");

            migrationBuilder.CreateIndex(
                "IX_Comments_TeacherId",
                "Comments",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_Consultations_StudentId",
                "Consultations",
                "StudentId");

            migrationBuilder.CreateIndex(
                "IX_Consultations_TeacherId",
                "Consultations",
                "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_Means_StudentId",
                "Means",
                "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_MeetingRequest_StudentId",
                "MeetingRequest",
                "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_MeetingRequest_TeacherId",
                "MeetingRequest",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_Sessions_TeacherId",
                "Sessions",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_Students_TeacherId",
                "Students",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_Years_SessionId",
                "Years",
                "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "BachelorThemes");

            migrationBuilder.DropTable(
                "CommentReplies");

            migrationBuilder.DropTable(
                "Consultations");

            migrationBuilder.DropTable(
                "Means");

            migrationBuilder.DropTable(
                "MeetingRequest");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "Years");

            migrationBuilder.DropTable(
                "Comments");

            migrationBuilder.DropTable(
                "Sessions");

            migrationBuilder.DropTable(
                "Students");

            migrationBuilder.DropTable(
                "Teachers");
        }
    }
}
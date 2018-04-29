using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BachelorManagement.DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Teachers",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>("nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>("nvarchar(max)", nullable: true),
                    LastName = table.Column<string>("nvarchar(max)", nullable: true),
                    NumberOfStudents = table.Column<int>("int", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Teachers", x => x.Id); });

            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>("nvarchar(max)", nullable: true),
                    Password = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Announcements",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>("nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>("datetime2", nullable: false),
                    TeacherId = table.Column<int>("int", nullable: false),
                    Title = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        "FK_Announcements_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Consultations",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<int>("int", nullable: false),
                    Interval = table.Column<string>("nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        "FK_Consultations_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Sessions",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherId = table.Column<int>("int", nullable: false)
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
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>("nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>("nvarchar(max)", nullable: true),
                    LastName = table.Column<string>("nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>("nvarchar(max)", nullable: true),
                    StartYear = table.Column<string>("nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>("int", nullable: false)
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
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<int>("int", nullable: false),
                    SpringSession = table.Column<bool>("bit", nullable: false),
                    SummerSession = table.Column<bool>("bit", nullable: false),
                    YearValue = table.Column<string>("nvarchar(max)", nullable: true)
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
                "Comments",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        "FK_Comments_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Files",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        "FK_Files_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Means",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    FifthSemester = table.Column<double>("float", nullable: false),
                    FirstSemester = table.Column<double>("float", nullable: false),
                    FourthSemester = table.Column<double>("float", nullable: false),
                    SecondSemester = table.Column<double>("float", nullable: false),
                    SixthSemester = table.Column<double>("float", nullable: false),
                    StudentId = table.Column<int>("int", nullable: false),
                    ThirdSemester = table.Column<double>("float", nullable: false)
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
                "StudentContents",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>("int", nullable: false),
                    Content = table.Column<string>("nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentContents", x => x.Id);
                    table.ForeignKey(
                        "FK_StudentContents_Comments_CommentId",
                        x => x.CommentId,
                        "Comments",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_StudentContents_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "TeacherContents",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>("int", nullable: false),
                    Content = table.Column<string>("nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherContents", x => x.Id);
                    table.ForeignKey(
                        "FK_TeacherContents_Comments_CommentId",
                        x => x.CommentId,
                        "Comments",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TeacherContents_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "FileContents",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>("varbinary(max)", nullable: true),
                    FileId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContents", x => x.Id);
                    table.ForeignKey(
                        "FK_FileContents_Files_FileId",
                        x => x.FileId,
                        "Files",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Grades",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    FileId = table.Column<int>("int", nullable: false),
                    GradeValue = table.Column<double>("float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        "FK_Grades_Files_FileId",
                        x => x.FileId,
                        "Files",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Announcements_TeacherId",
                "Announcements",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_Comments_StudentId",
                "Comments",
                "StudentId");

            migrationBuilder.CreateIndex(
                "IX_Consultations_TeacherId",
                "Consultations",
                "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_FileContents_FileId",
                "FileContents",
                "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Files_StudentId",
                "Files",
                "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Grades_FileId",
                "Grades",
                "FileId");

            migrationBuilder.CreateIndex(
                "IX_Means_StudentId",
                "Means",
                "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Sessions_TeacherId",
                "Sessions",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_StudentContents_CommentId",
                "StudentContents",
                "CommentId");

            migrationBuilder.CreateIndex(
                "IX_StudentContents_StudentId",
                "StudentContents",
                "StudentId");

            migrationBuilder.CreateIndex(
                "IX_Students_TeacherId",
                "Students",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_TeacherContents_CommentId",
                "TeacherContents",
                "CommentId");

            migrationBuilder.CreateIndex(
                "IX_TeacherContents_TeacherId",
                "TeacherContents",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_Years_SessionId",
                "Years",
                "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Announcements");

            migrationBuilder.DropTable(
                "Consultations");

            migrationBuilder.DropTable(
                "FileContents");

            migrationBuilder.DropTable(
                "Grades");

            migrationBuilder.DropTable(
                "Means");

            migrationBuilder.DropTable(
                "StudentContents");

            migrationBuilder.DropTable(
                "TeacherContents");

            migrationBuilder.DropTable(
                "User");

            migrationBuilder.DropTable(
                "Years");

            migrationBuilder.DropTable(
                "Files");

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
using System;
using System.Linq;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.DataLayer.Enums;

namespace BachelorManagement.DataLayer
{
    public class BachelorManagementInitializeDb
    {
        public static void Initialize(BachelorManagementContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
                return;

            var teachers = new[]
            {
                new Teacher
                {
                    Email = "vlad.simion@info.uaic.ro",
                    FirstName = "Vlad",
                    LastName = "Simion",
                    NumberOfSpots = 10,
                    NumberOfAvailableSpots = 8,
                    JobTitle = "Colab.",
                    Discipline = "Introduction to programming",
                    Requirement = "No special requirements"
                },
                new Teacher
                {
                    Email = "simona.petrescu@info.uaic.ro",
                    FirstName = "Simona",
                    LastName = "Petrescu",
                    NumberOfSpots = 8,
                    NumberOfAvailableSpots = 8,
                    JobTitle = "Prof. Dr.",
                    Discipline = "Data structures"
                },
                new Teacher
                {
                    Email = "andrei.mihalache@info.uaic.ro",
                    FirstName = "Andrei",
                    LastName = "Mihalache",
                    NumberOfSpots = 5,
                    NumberOfAvailableSpots = 3,
                    JobTitle = "Prof.",
                    Discipline = "Object Oriented Programming",
                    Requirement = "Positive attitude towards this degree"
                },
                new Teacher
                {
                    Email = "daniela.pavelescu@info.uaic.ro",
                    FirstName = "Daniela",
                    LastName = "Pavelescu",
                    NumberOfSpots = 15,
                    NumberOfAvailableSpots = 6,
                    JobTitle = "Colab.",
                    Discipline = "Introduction to programming",
                    Requirement = "Grades greater than 8"
                }
            };
            foreach (var teacher in teachers)
                context.Teachers.Add(teacher);
            context.SaveChanges();

            var students = new[]
            {
                new Student
                {
                    Email = "ana.florea@info.uaic.ro",
                    FirstName = "Ana",
                    LastName = "Florea",
                    SerialNumber = "31090104SL161234",
                    StartYear = "2016",
                    TeacherId = 1,
                    Achievements = "No special achievements",
                    GitUrl = "https://github.com/Tanasa-Nicoleta/bachelorManagement",
                    Accepted = false,
                    Denied = false,
                    Pending = true
                },
                new Student
                {
                    Email = "mihai.ursache@info.uaic.ro",
                    FirstName = "Mihai",
                    LastName = "Ursache",
                    SerialNumber = "31090104SL141235",
                    StartYear = "2014",
                    TeacherId = 1,
                    Achievements = "Onis participation",
                    GitUrl = "https://github.com/Tanasa-Nicoleta/bachelorManagement",
                    Accepted = true,
                    Denied = false,
                    Pending = false
                },
                new Student
                {
                    Email = "george.leu@info.uaic.ro",
                    FirstName = "George",
                    LastName = "Leu",
                    SerialNumber = "31090104SL151236",
                    StartYear = "2015",
                    TeacherId = 1,
                    Achievements = "none",
                    GitUrl = "https://github.com/Tanasa-Nicoleta/bachelorManagement",
                    Accepted = true,
                    Denied = false,
                    Pending = false,
                },
                new Student
                {
                    Email = "daniel.ion@info.uaic.ro",
                    FirstName = "Daniel",
                    LastName = "Ion",
                    SerialNumber = "31090104SL151237",
                    StartYear = "2015",
                    TeacherId = 2,
                    Achievements = "none",
                    GitUrl = "https://github.com/Tanasa-Nicoleta/bachelorManagement",
                    Accepted = true,
                    Denied = false,
                    Pending = false,
                }
            };
            foreach (var student in students)
                context.Students.Add(student);
            context.SaveChanges();

            var bachelorThemes = new[]
            {
                new BachelorTheme
                {
                    Description = "Machine learning and deep learning study",
                    TeacherId = 1,
                    Title = "Machine learning"
                },
                new BachelorTheme
                {
                    Description = "Web application to help students from FII to be organised",
                    TeacherId = 2,
                    Title = "FII organised"
                },
                new BachelorTheme
                {
                    Description = "Research about time consuming application and how this applications could be imporved",
                    TeacherId = 3,
                    Title = "Time consuming application"
                },
                new BachelorTheme
                {
                    Description = "Apllication that teaches the usesrs all kind of tricks to stop polluting",
                    TeacherId = 4,
                    Title = "Save Earth"
                },
                new BachelorTheme
                {
                    Description = "Web application for students and coordinators that contains many ways to make the bachelor degree development easier",
                    StudentId = 2,
                    Title = "Bachelor Degree Management"
                },
                new BachelorTheme
                {
                    Description = "All kind of products can be purchased using this application",
                    StudentId = 1,
                    Title = "Online ordering"
                },
                new BachelorTheme
                {
                    Description = "Interactive multiplayer game",
                    StudentId = 3,
                    Title = "Gamer"
                }
            };
            foreach (var theme in bachelorThemes)
                context.BachelorThemes.Add(theme);
            context.SaveChanges();

            var comments = new[]
            {
                new Comment
                {
                    TeacherId = 1,
                    CommentContent = "Hello! I hope that very soon we will celebrate you as fresh graduates. :)",
                    Date = DateTime.Now.AddDays(-12)
                },
                new Comment
                {
                    TeacherId = 1,
                    CommentContent = "Hello! Welcome to my page!",
                    Date = DateTime.Now.AddDays(-24)
                }
            };
            foreach (var comment in comments)
                context.Comments.Add(comment);
            context.SaveChanges();

            var commentReplies = new[]
            {
                new CommentReply
                {
                    CommentId = 1,
                    CommentReplyContent = "We hope this, too! See you soon.",
                    Date = DateTime.Now.AddDays(-10.5)
                },
                new CommentReply
                {
                    CommentId = 2,
                    CommentReplyContent = "Hei! Thank you! Looking forward to get to work.",
                    Date = DateTime.Now.AddDays(-23.5)
                }
            };
            foreach (var commentReply in commentReplies)
                context.CommentReplies.Add(commentReply);
            context.SaveChanges();

            var consultations = new[]
            {
                new Consultation
                {
                    Day = WeekDays.Monday,
                    Interval = "09:00 - 11:00",
                    TeacherId = 1
                },
                new Consultation
                {
                    Day = WeekDays.Monday,
                    Interval = "09:00 - 11:00",
                    TeacherId = 2
                }
            };
            foreach (var consultation in consultations)
                context.Consultations.Add(consultation);
            context.SaveChanges();

            var means = new[]
            {
                new Mean
                {
                    StudentId = 1,
                    FirstSemester = 8.20,
                    SecondSemester = 9.00,
                    ThirdSemester = 7.80
                },
                new Mean
                {
                    StudentId = 2,
                    FirstSemester = 9.20,
                    SecondSemester = 9.00,
                    ThirdSemester = 9.80,
                    FourthSemester = 9.30,
                    FifthSemester = 9.00,
                    SixthSemester = 9.40
                },
                new Mean
                {
                    StudentId = 3,
                    FirstSemester = 9.20,
                    SecondSemester = 9.00,
                    ThirdSemester = 9.80,
                    FourthSemester = 9.30,
                    FifthSemester = 9.00
                },
                new Mean
                {
                    StudentId = 4,
                    FirstSemester = 9.20,
                    SecondSemester = 9.00,
                    ThirdSemester = 9.80,
                    FourthSemester = 9.30,
                    FifthSemester = 9.00
                }
            };
            foreach (var mean in means)
                context.Means.Add(mean);
            context.SaveChanges();

            var sessions = new[]
            {
                new Session
                {
                    TeacherId = 1
                },
                new Session
                {
                    TeacherId = 2
                }
            };
            foreach (var session in sessions)
                context.Sessions.Add(session);
            context.SaveChanges();

            var users = new[]
            {
                new User
                {
                    Email = "ana.florea@info.uaic.ro",
                    Password = "Ana123!",
                    UserType = UserType.Student
                },
                new User
                {
                    Email = "mihai.ursache@info.uaic.ro",
                    Password = "Mihai123!",
                    UserType = UserType.Student
                },
                new User
                {
                    Email = "george.leu@info.uaic.ro",
                    Password = "George123!",
                    UserType = UserType.Student
                },

                new User
                {
                    Email = "vlad.simion@info.uaic.ro",
                    Password = "Vlad123!",
                    UserType = UserType.Teacher
                },
                new User
                {
                    Email = "simona.petrescu@info.uaic.ro",
                    Password = "Simona123!",
                    UserType = UserType.Teacher
                }
                ,
                new User
                {
                    Email = "admin.admin@info.uaic.ro",
                    Password = "Admin123!",
                    UserType = UserType.Student
                }
            };
            foreach (var user in users)
                context.Users.Add(user);
            context.SaveChanges();

            var years = new[]
            {
                new Year
                {
                    YearValue = "2018",
                    SpringSession = true,
                    SummerSession = true,
                    SessionId = 1
                },

                new Year
                {
                    YearValue = "2018",
                    SpringSession = true,
                    SummerSession = true,
                    SessionId = 2
                }
            };
            foreach (var year in years)
                context.Years.Add(year);
            context.SaveChanges();

            var meetingRequests = new[]
            {
                new MeetingRequest
                {
                    StudentId = 1,
                    TeacherId = 1,
                    Date = DateTime.Now.AddDays(2),
                    Status = MeetingRequestStatus.Pending
                }
            };
            foreach(var meeting in meetingRequests)
                context.MeetingRequests.Add(meeting);
            context.SaveChanges();
        }
    }
}
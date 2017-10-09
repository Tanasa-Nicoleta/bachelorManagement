using System;
using System.Linq;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;

namespace BusinessLayer
{
    public class BachelorManagementInitializeDb
    {
        public static void Initialize(BachelorManagementContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var announcements = new[]
            {
                new Announcement
                {
                    Id = 1,
                    TeacherId = 1,
                    Title = "First",
                    Content = "First announcement",
                    Date = DateTime.Now
                },
                new Announcement
                {
                    Id = 1,
                    TeacherId = 2,
                    Title = "Second",
                    Content = "Second announcement",
                    Date = DateTime.Now
                }
            };
            foreach (var announcement in announcements)
            {
                context.Announcements.Add(announcement);
            }
            context.SaveChanges();

            var comments = new[]
            {
                new Comment
                {
                    Id = 1,
                    StudentId = 1
                },
                new Comment
                {
                    Id = 2,
                    StudentId = 2
                },
                new Comment
                {
                    Id = 3,
                    StudentId = 1
                },
                new Comment
                {
                    Id = 4,
                    StudentId = 2
                }
            };
            foreach (var comment in comments)
            {
                context.Comments.Add(comment);
            }
            context.SaveChanges();

            var consultations = new[]
            {
                new Consultation
                {
                    Id = 1,
                    Day = WeekDays.Monday,
                    Interval = "09:00 - 11:00",
                    TeacherId = 1
                },

                new Consultation
                {
                    Id = 2,
                    Day = WeekDays.Thursday,
                    Interval = "10:00 - 12:00",
                    TeacherId = 2
                }
            };
            foreach (var consultation in consultations)
            {
                context.Consultations.Add(consultation);
            }
            context.SaveChanges();

            var means = new[]
            {
                new Mean
                {
                    Id = 1,
                    StudentId = 1,
                    FirstSemester = 8.20,
                    SecondSemester = 9.00,
                    ThirdSemester = 7.80
                },
                new Mean
                {
                    Id = 3,
                    StudentId = 2,
                    FirstSemester = 6.00,
                    SecondSemester = 6.20,
                    ThirdSemester = 7.00
                },
                new Mean
                {
                    Id = 3,
                    StudentId = 3,
                    FirstSemester = 9.20,
                    SecondSemester = 9.00,
                    ThirdSemester = 9.80,
                    FourthSemester = 9.30,
                    FifthSemester = 9.00
                }
            };
            foreach (var mean in means)
            {
                context.Means.Add(mean);
            }
            context.SaveChanges();

            var sessions = new[]
            {
                new Session
                {
                    Id = 1,
                    TeacherId = 1
                },
                new Session
                {
                    Id = 2,
                    TeacherId = 2
                }
            };
            foreach (var session in sessions)
            {
                context.Sessions.Add(session);
            }
            context.SaveChanges();

            var students = new[]
            {
                new Student
                {
                    Id = 1,
                    Email = "ana.florea@info.uaic.ro",
                    FirstName = "Ana",
                    LastName = "Florea",
                    MeanId = 1,
                    SerialNumber = "31090104SL161234",
                    StartYear = "2016",
                    TeacherId = 1
                },
                new Student
                {
                    Id = 1,
                    Email = "mihai.ursache@info.uaic.ro",
                    FirstName = "Mihai",
                    LastName = "Ursache",
                    MeanId = 2,
                    SerialNumber = "31090104SL141235",
                    StartYear = "2014",
                    TeacherId = 1
                },
                new Student
                {
                    Id = 1,
                    Email = "george.leu@info.uaic.ro",
                    FirstName = "George",
                    LastName = "Leu",
                    MeanId = 3,
                    SerialNumber = "31090104SL151234",
                    StartYear = "2015",
                    TeacherId = 2
                }
            };
            foreach (var student in students)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();

            var studentContents = new[]
            {
                new StudentContent
                {
                    Id = 1,
                    StudentId = 1,
                    CommentId = 1,
                    Content = "Good job!"
                },
                new StudentContent
                {
                    Id = 2,
                    StudentId = 2,
                    CommentId = 2,
                    Content = "Great job!"
                }
            };
            foreach (var studentContent in studentContents)
            {
                context.StudentContents.Add(studentContent);
            }
            context.SaveChanges();

            var teachers = new[]
            {
                new Teacher
                {
                    Id = 1,
                    Email = "vlad.simion@info.uaic.ro",
                    FirstName = "Vlad",
                    LastName = "Simion",
                    NumberOfStudents = 10,
                    ConsultationId = 1
                },
                new Teacher
                {
                    Id = 2,
                    Email = "simona.petrescu@info.uaic.ro",
                    FirstName = "Simona",
                    LastName = "Petrescu",
                    NumberOfStudents = 10,
                    ConsultationId = 2
                }
            };
            foreach (var teacher in teachers)
            {
                context.Teachers.Add(teacher);
            }
            context.SaveChanges();


            var teacherContents = new[]
            {
                new TeacherContent
                {
                    Id = 1,
                    TeacherId = 1,
                    CommentId = 3,
                    Content = "Good job!"
                },
                new TeacherContent
                {
                    Id = 2,
                    TeacherId = 2,
                    CommentId = 4,
                    Content = "Great job!"
                }
            };
            foreach (var teacherContent in teacherContents)
            {
                context.TeacherContents.Add(teacherContent);
            }
            context.SaveChanges();

            var users = new[]
            {
                new User
                {
                    Id = 1,
                    Email = "ana.florea@info.uaic.ro",
                    Password = "Ana123!",
                    UserType = UserType.Student
                },
                new User
                {
                    Id = 1,
                    Email = "mihai.ursache@info.uaic.ro",
                    Password = "Mihai123!",
                    UserType = UserType.Student
                },
                new User
                {
                    Id = 1,
                    Email = "george.leu@info.uaic.ro",
                    Password = "George123!",
                    UserType = UserType.Student
                },

                new User
                {
                    Id = 1,
                    Email = "vlad.simion@info.uaic.ro",
                    Password = "Vlad123!",
                    UserType = UserType.Teacher
                },
                new User
                {
                    Id = 1,
                    Email = "simona.petrescu@info.uaic.ro",
                    Password = "Simona123!",
                    UserType = UserType.Teacher
                }
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var years = new[]
            {
                new Year
                {
                    Id = 1,
                    YearValue = "2018",
                    SpringSession = true,
                    SummerSession = true,
                    SessionId = 1
                },

                new Year
                {
                    Id = 1,
                    YearValue = "2018",
                    SpringSession = true,
                    SummerSession = true,
                    SessionId = 2
                }
            };
            foreach (var year in years)
            {
                context.Years.Add(year);
            }
            context.SaveChanges();
        }
    }
}

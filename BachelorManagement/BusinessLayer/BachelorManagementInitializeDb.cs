using System;
using System.Linq;
using DataLayer;
using DataLayer.Entities;

namespace BusinessLayer
{
    internal class BachelorManagementInitializeDb
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
            foreach (var a in announcements)
            {
                context.Announcements.Add(a);
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
            foreach(var u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

        }
    }
}

﻿using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class BachelorManagementContext: DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Consultation> Consultations { get; set; }

        public virtual DbSet<File> Files { get; set; }

        public virtual DbSet<FileContent> FileContents { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Mean> Means { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentContent> StudentContents { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<TeacherContent> TeacherContents { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Year> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BachelorManagement;Trusted_Connection=True;");
        }

    }
}

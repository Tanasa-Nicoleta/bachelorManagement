using BachelorManagement.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BachelorManagement.DataLayer
{
    public class BachelorManagementContext : DbContext
    {
        public BachelorManagementContext(DbContextOptions<BachelorManagementContext> options) : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<Mean> Means { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<BachelorTheme> BachelorThemes { get; set; }
        public virtual DbSet<CommentReply> CommentReplies { get; set; }
        public virtual DbSet<MeetingRequest> MeetingRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cn = @"Server=localhost;Database=BachelorDegreeManagementV11;integrated security=SSPI;";
            optionsBuilder.UseSqlServer(cn);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
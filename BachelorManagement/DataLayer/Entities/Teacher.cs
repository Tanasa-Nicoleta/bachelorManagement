using System.Collections.Generic;
using BusinessLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Teacher : IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int NumberOfStudents { get; set; }
        public Consultation Consultation { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public int Id { get; set; }
    }
}
using System.Collections.Generic;

namespace BachelorManagement.DataLayer.Entities
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
        public string Discipline { get; set; }
        public ICollection<BachelorTheme> Themes { get; set; }
        public int Id { get; set; }
    }
}
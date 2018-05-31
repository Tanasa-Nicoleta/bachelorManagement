using System.Collections.Generic;

namespace BachelorManagement.DataLayer.Entities
{
    public class Teacher : IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int NumberOfSpots { get; set; }
        public int NumberOfAvailableSpots { get; set; }
        public Consultation Consultation { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public string Discipline { get; set; }
        public ICollection<BachelorTheme> BachelorThemes { get; set; }
        public ICollection<MeetingRequest> MeetingRequests { get; set; }
        public string Requirement { get; set; }
        public string JobTitle { get; set; }
        public int Id { get; set; }
    }
}
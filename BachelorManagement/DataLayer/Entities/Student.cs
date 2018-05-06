using System.Collections.Generic;

namespace BachelorManagement.DataLayer.Entities
{
    public class Student : IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SerialNumber { get; set; }
        public string StartYear { get; set; }
        public int TeacherId { get; set; }
        public Mean Mean { get; set; }
        public Teacher Teacher { get; set; }
        public string Achievements { get; set; }
        public MeetingRequest MeetingRequest { get; set; }
        public BachelorTheme BachelorTheme { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string GitUrl { get; set; }
        public int Id { get; set; }
        public bool Accepted { get; set; }
        public bool Denied { get; set; } 
    }
}
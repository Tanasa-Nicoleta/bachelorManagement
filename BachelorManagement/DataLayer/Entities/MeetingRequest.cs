using System;

namespace BachelorManagement.DataLayer.Entities
{
    public class MeetingRequest : IEntityBase
    {
        public DateTime Date { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public int Id { get; set; }
    }
}
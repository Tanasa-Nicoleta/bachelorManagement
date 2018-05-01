using BachelorManagement.DataLayer.Enums;

namespace BachelorManagement.DataLayer.Entities
{
    public class Consultation : IEntityBase
    {
        public WeekDays Day { get; set; }
        public string Interval { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public int Id { get; set; }
    }
}
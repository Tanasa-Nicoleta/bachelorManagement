using DataLayer.Enums;
using BusinessLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Consultation : IEntityBase
    {
        public WeekDays Day { get; set; }
        public string Interval { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int Id { get; set; }
    }
}
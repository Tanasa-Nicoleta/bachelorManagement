using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Consultation : IEntityBase
    {
        public string Day { get; set; }
        public string Interval { get; set; }
        public Teacher Teacher { get; set; }
        public int Id { get; set; }
    }
}
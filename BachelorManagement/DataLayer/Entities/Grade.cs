using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Grade : IEntityBase
    {
        public double GradeValue { get; set; }
        public int Id { get; set; }
    }
}
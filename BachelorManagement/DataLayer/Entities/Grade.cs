using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Grade : IEntityBase
    {
        public double GradeValue { get; set; }
        public int FileId { get; set; }
        public File File { get; set; }
        public int Id { get; set; }
    }
}
using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class StudentContent : IEntityBase
    {
        public string Content { get; set; }
        public Comment Comment { get; set; }
        public Student Student { get; set; }
        public int Id { get; set; }
    }
}
using System.Collections.Generic;
using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class File : IEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StudentId { get; set; }
        public FileContent FileContent { get; set; }
        public Student Student { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public int Id { get; set; }
    }
}
using System.Collections.Generic;

namespace BachelorManagement.DataLayer.Entities
{
    public class Comment : IEntityBase
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public ICollection<StudentContent> StudentContents { get; set; }
        public ICollection<TeacherContent> TeacherContents { get; set; }
        public int Id { get; set; }
    }
}
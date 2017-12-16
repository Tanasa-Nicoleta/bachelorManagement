using BachelorManagement.BusinessLayer.Interfaces;

namespace BachelorManagement.DataLayer.Entities
{
    public class TeacherContent : IEntityBase
    {
        public string Content { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public Teacher Teacher { get; set; }
        public int Id { get; set; }
    }
}
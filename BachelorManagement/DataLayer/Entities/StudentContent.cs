namespace BachelorManagement.DataLayer.Entities
{
    public class StudentContent : IEntityBase
    {
        public string Content { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public Student Student { get; set; }
        public int Id { get; set; }
    }
}
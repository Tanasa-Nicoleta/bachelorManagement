namespace BachelorManagement.DataLayer.Entities
{
    public class Comment : IEntityBase
    {
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string CommentContent { get; set; }
        public int Id { get; set; }
    }
}
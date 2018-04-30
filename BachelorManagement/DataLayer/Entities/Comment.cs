namespace BachelorManagement.DataLayer.Entities
{
    public class Comment : IEntityBase
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Id { get; set; }
    }
}
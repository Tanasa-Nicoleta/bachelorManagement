namespace BachelorManagement.DataLayer.Entities
{
    public class BachelorTheme: IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int? StudentId { get; set; } 
        public Student Student { get; set; }
    }
}
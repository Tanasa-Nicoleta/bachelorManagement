namespace BachelorManagement.DataLayer.Entities
{
    public class BachelorTheme: IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public int StudentID { get; set; }
    }
}
namespace BachelorManagement.DataLayer.Entities
{
    public class Year : IEntityBase
    {
        public string YearValue { get; set; }
        public bool SpringSession { get; set; }
        public bool SummerSession { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int Id { get; set; }
    }
}
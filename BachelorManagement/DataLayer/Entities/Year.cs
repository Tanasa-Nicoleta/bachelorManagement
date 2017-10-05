using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Year : IEntityBase
    {
        public string YearValue { get; set; }
        public bool SpringSession { get; set; }
        public bool SummerSession { get; set; }
        public int Id { get; set; }
    }
}
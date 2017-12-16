using BachelorManagement.BusinessLayer.Interfaces;

namespace BachelorManagement.DataLayer.Entities
{
    public class Mean : IEntityBase
    {
        public double FirstSemester { get; set; }
        public double SecondSemester { get; set; }
        public double ThirdSemester { get; set; }
        public double FourthSemester { get; set; }
        public double FifthSemester { get; set; }
        public double SixthSemester { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Id { get; set; }
    }
}
namespace BachelorManagement.ApiLayer.Models
{
    public class TeacherDto
    {
        public string AdminEmail { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int NumberOfSpots { get; set; }
        public string Discipline { get; set; }
        public string JobTitle { get; set; }
        public string Token { get; set; }
    }
}

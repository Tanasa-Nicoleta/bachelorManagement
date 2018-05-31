using BachelorManagement.DataLayer.Entities;

namespace BachelorManagement.ApiLayer.Models
{
    public class StudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Achievements { get; set; }
        public BachelorTheme BachelorTheme { get; set; }
        public string GitUrl { get; set; }
        public bool Accepted { get; set; }
        public bool Denied { get; set; }
    }
}

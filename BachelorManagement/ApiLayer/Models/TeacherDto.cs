namespace BachelorManagement.ApiLayer.Models
{
    public class TeacherDto
    {
        public string Email { get; set; }
        public int NoOfAvailableSpots { get; set; }
        public string Requirement { get; set; }
        public string ThemeTitle { get; set; }
        public string ThemeDescription { get; set; }
    }
}
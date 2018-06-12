namespace BachelorManagement.ApiLayer.Models
{
    public class TeacherDetailsDto 
    {
        public string Email { get; set; }
        public int NoOfAvailableSpots { get; set; }
        public string Requirement { get; set; }
        public string ThemeTitle { get; set; }
        public string ThemeDescription { get; set; }
        public string Token { get; set; }
    }
}
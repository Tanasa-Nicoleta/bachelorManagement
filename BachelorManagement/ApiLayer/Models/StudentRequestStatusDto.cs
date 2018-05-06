namespace BachelorManagement.ApiLayer.Models
{
    public class StudentRequestStatusDto
    {
        public string Email { get; set; }
        public bool Accepted { get; set; }
        public bool Denied { get; set; }
    }
}

namespace BachelorManagement.ApiLayer.Models
{
    public class StudentRequestStatusDto
    {
        public string TeacherEmail { get; set; }
        public string StudentEmail { get; set; }
        public bool Accepted { get; set; }
        public bool Denied { get; set; }
    }
}
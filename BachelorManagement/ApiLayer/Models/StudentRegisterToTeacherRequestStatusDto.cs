namespace BachelorManagement.ApiLayer.Models
{
    public class StudentRegisterToTeacherRequestStatusDto
    {
        public string TeacherEmail { get; set; }
        public string StudentEmail { get; set; }
        public bool Accepted { get; set; }
        public bool Denied { get; set; }
        public string Token { get; set; }
    }
}
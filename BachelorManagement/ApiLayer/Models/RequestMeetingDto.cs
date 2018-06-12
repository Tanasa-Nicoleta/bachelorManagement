using System;

namespace BachelorManagement.ApiLayer.Models
{
    public class RequestMeetingDto
    {
        public string TeacherEmail { get; set; }
        public string StudentEmail { get; set; }
        public DateTime? Date { get; set; }
        public string Token { get; set; }
    }
}

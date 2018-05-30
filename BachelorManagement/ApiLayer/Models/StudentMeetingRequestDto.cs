using System;

namespace BachelorManagement.ApiLayer.Models
{
    public class StudentMeetingRequestDto
    {
        public string TeacherEmail { get; set; }
        public string StudentEmail { get; set; }
        public DateTime Date { get; set; }
    }
}

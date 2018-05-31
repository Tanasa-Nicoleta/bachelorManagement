using System;

namespace BachelorManagement.ApiLayer.Models
{
    public class PostDto
    {
        public string StudentEmail { get; set; }

        public string TeacherEmail { get; set; }

        public string CommentContent { get; set; }

        public DateTime Date { get; set; }
    }
}

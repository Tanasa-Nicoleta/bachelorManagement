﻿namespace BachelorManagement.ApiLayer.Models
{
    public class EditStudentDto
    {
        public string Email { get; set; } 
        public string BachelorThemeTitle { get; set; }
        public string BachelorThemeDescription { get; set; }
        public string GitUrl { get; set; }
        public bool Pending { get; set; }
        public string Token { get; set; }
    }
}

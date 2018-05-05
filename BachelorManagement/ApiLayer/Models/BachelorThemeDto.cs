﻿using System.ComponentModel.DataAnnotations;

namespace BachelorManagement.ApiLayer.Models
{
    public class BachelorThemeDto
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Achievement { get; set; }
        public string UserEmail { get; set; }
    }
}

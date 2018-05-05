﻿using BachelorManagement.ApiLayer.Models;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IBachelorThemeService _bachelorThemeService;

        public StudentController(IStudentService studentService, IBachelorThemeService bachelorThemeService)
        {
            _studentService = studentService;
            _bachelorThemeService = bachelorThemeService;
        }

        [HttpGet]
        [Route("api/student/{email}")]
        public IActionResult GetStudent(string email)
        {
            return Ok(_studentService.GetStudentByEmail(email));
        }

        [HttpGet]
        [Route("api/student/teacher/{email}")]
        public IActionResult GetStudentTeacher(string email)
        {
            return Ok(_studentService.GetStudentsTeacher(email));
        }

        [HttpGet]
        [Route("api/student/themes/{email}")]
        public IActionResult GetStudentsThemes(string email)
        {
            return Ok(_studentService.GetStudentBachelorThemes(email));
        }

        [HttpGet]
        [Route("api/student/means/{email}")]
        public IActionResult GetStudentMeans(string email)
        {
            return Ok(_studentService.GetStudentMeans(email));
        }

        [HttpPost]
        [Route("api/student/addTheme")]
        public IActionResult AddTheme([FromBody] BachelorThemeDto bachelorThemeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _studentService.AddAchievementToStudent(bachelorThemeDto.UserEmail, bachelorThemeDto.Achievement);
            _bachelorThemeService.AddBachelorThemeToStudent(bachelorThemeDto.UserEmail, bachelorThemeDto.Title, bachelorThemeDto.Description);

            return Ok();
        }
    }
}
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly ITeacherService _teacherService;

        public AdminController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("addTeacher")]
        public IActionResult AddTeacher([FromBody] TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _teacherService.AddTeacher(
                new Teacher
                { 
                    FirstName = teacherDto.FirstName,
                    LastName = teacherDto.LastName,
                    Discipline = teacherDto.Discipline,
                    Email = teacherDto.Email,
                    NumberOfSpots = teacherDto.NumberOfSpots,
                    JobTitle = teacherDto.JobTitle
                }
                );

            return Ok();
        }

        [HttpPost("removeTeacher")]
        public IActionResult RemoveTeacher([FromBody] TeacherRemoveDto teacherRemoveDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _teacherService.RemoveTeacher(teacherRemoveDto.Email);

            return Ok();
        }

    }
}
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BachelorManagement.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IAccountService _accountService;

        public AdminController(ITeacherService teacherService, IAccountService accountService)
        {
            _teacherService = teacherService;
            _accountService = accountService;
        }

        [HttpPost("addTeacher")]
        public IActionResult AddTeacher([FromBody] TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(teacherDto.Email, new Guid(teacherDto.Token)))
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

            if (!_accountService.CheckTheTokenValidity(teacherRemoveDto.Email, new Guid(teacherRemoveDto.Token)))
                return BadRequest();

            _teacherService.RemoveTeacher(teacherRemoveDto.Email);

            return Ok();
        }

        [HttpPut("editTeacher")]
        public IActionResult EditTeacher([FromBody] TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(teacherDto.Email, new Guid(teacherDto.Token)))
                return BadRequest();

            _teacherService.EditTeacher(
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

    }
}
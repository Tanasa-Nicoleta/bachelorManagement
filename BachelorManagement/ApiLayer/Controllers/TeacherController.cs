﻿using System.Collections.Generic;
using System.Linq;
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly ICommentReplyService _commentReplyService;
        private readonly IMeetingRequestService _meetingRequestService;

        public TeacherController(ITeacherService teacherService,
            ICommentReplyService commentReplyService,
            IMeetingRequestService meetingRequestService,
            IStudentService studentService)
        {
            _teacherService = teacherService;
            _commentReplyService = commentReplyService;
            _meetingRequestService = meetingRequestService;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("api/teacher")]
        public IActionResult Get()
        {
            return Ok(_teacherService.GetAllTeachers());
        }

        [HttpGet]
        [Route("api/teacher/{email}")]
        public IActionResult GetTeacher(string email)
        {
            return Ok(_teacherService.GetTeacherByEmail(email));
        }

        [HttpGet]
        [Route("api/teacher/themes/{email}")]
        public IActionResult GetTeacherThemes(string email)
        {
            return Ok(_teacherService.GetTeacherBachelorThemes(email));
        }

        [HttpGet]
        [Route("api/teacher/students/{email}")]
        public IActionResult GetTeacherStudents(string email)
        {
            return Ok(_teacherService.GetTeacherStudents(email));
        }

        [HttpPost]
        [Route("api/teacher/addDetails")]
        public IActionResult AddTeacherDetails([FromBody] TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _teacherService.AddDetailsToTeacher(teacherDto.Email, teacherDto.Requirement, teacherDto.NoOfAvailableSpots,
                teacherDto.ThemeTitle, teacherDto.ThemeDescription);

            return Ok();
        }

        [HttpGet]
        [Route("api/teacher/comments/{email}")]
        public IActionResult GetTeacherComments(string email)
        {
            return Ok(_teacherService.GetTeacherComments(email));
        }

        [HttpGet]
        [Route("api/teacher/comments/{email}/{id}")]
        public IActionResult GetTeacherCommentReplies(string email, int id)
        {
            var commentReplies = new List<CommentReply>();
            var comments = _teacherService.GetTeacherComments(email).Where(c => c.Id == id);
            foreach (var comment in comments)
            {
                commentReplies.AddRange(_commentReplyService.GetCommentReplies(comment.Id));
            }
            return Ok(commentReplies);
        }

        [HttpGet]
        [Route("api/teacher/studentMeetingRequest/{email}")]
        public IActionResult GetTeacherMeetingRequest(string email)
        {
            var teacher = _teacherService.GetTeacherByEmail(email);
            List<MeetingRequest> meetingRequests = new List<MeetingRequest>();

            if (teacher != null)
            {
                meetingRequests = _meetingRequestService.GetTeacherMeetingRequests(teacher.Id);
            }

            var meetingRequestDto = new List<StudentMeetingRequestDto>();
            foreach (var meetingRequest in meetingRequests)
            {
                meetingRequestDto.Add(
                    new StudentMeetingRequestDto
                    {
                        Date = meetingRequest.Date,
                        StudentEmail = _studentService.GetStudentById(meetingRequest.StudentId.Value).Email,
                        TeacherEmail = _teacherService.GetTeacherById(meetingRequest.TeacherId.Value).Email
                    }
                );
            };

            return Ok(meetingRequestDto);
        }
    }
}
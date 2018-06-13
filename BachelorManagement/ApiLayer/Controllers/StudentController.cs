using System.Collections.Generic;
using System.Linq;
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using BachelorManagement.ApiLayer.Utils;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly IBachelorThemeService _bachelorThemeService;
        private readonly IStudentService _studentService;
        private readonly ICommentReplyService _commentReplyService;
        private readonly ICommentService _commentService;
        private readonly ITeacherService _teacherService;
        private readonly IMeetingRequestService _meetingRequestService;
        private readonly IAccountService _accountService;

        public StudentController(IStudentService studentService,
            IBachelorThemeService bachelorThemeService,
            ICommentReplyService commentReplyService,
            ITeacherService teacherService,
            IMeetingRequestService meetingRequestService,
            ICommentService commentService,
            IAccountService accountService)
        {
            _studentService = studentService;
            _bachelorThemeService = bachelorThemeService;
            _commentReplyService = commentReplyService;
            _teacherService = teacherService;
            _meetingRequestService = meetingRequestService;
            _commentService = commentService;
            _accountService = accountService;
        }

        [HttpGet]
        [Route("api/student/{email}/{token}")]
        public IActionResult GetStudent(string email, string token)
        {
            if (!Token.CheckTokenFormat(token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            return Ok(_studentService.GetStudentByEmail(email));
        }

        [HttpGet]
        [Route("api/student/teacher/{email}/{token}")]
        public IActionResult GetStudentTeacher(string email, string token)
        {
            if (!Token.CheckTokenFormat(token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            return Ok(_studentService.GetStudentsTeacher(email));                      
        }

        [HttpGet]
        [Route("api/student/themes/{userEmail}/{email}/{token}")]
        public IActionResult GetStudentsThemes(string userEmail, string email, string token)
        {
            if (!Token.CheckTokenFormat(token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(userEmail, new Guid(token)))
                return BadRequest();

            return Ok(_studentService.GetStudentBachelorThemes(email));            
        }

        [HttpGet]
        [Route("api/student/means/{email}/{token}")]
        public IActionResult GetStudentMeans(string email, string token)
        {
            if (!Token.CheckTokenFormat(token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            return Ok(_studentService.GetStudentMeans(email));            
        }

        [HttpPost]
        [Route("api/student/addTheme")]
        public IActionResult AddTheme([FromBody] BachelorThemeDto bachelorThemeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!Token.CheckTokenFormat(bachelorThemeDto.Token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(bachelorThemeDto.Email, new Guid(bachelorThemeDto.Token)))
                return BadRequest();

            _studentService.AddAchievementToStudent(bachelorThemeDto.Email, bachelorThemeDto.Achievement);
            _bachelorThemeService.AddBachelorThemeToStudent(bachelorThemeDto.Email, bachelorThemeDto.Title,
                bachelorThemeDto.Description);

            return Ok();
        }

        [HttpPost]
        [Route("api/student/teacherRequestStatus")]
        public IActionResult UpdateStudentRequest([FromBody] StudentRegisterToTeacherRequestStatusDto studentRequestStatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!Token.CheckTokenFormat(studentRequestStatusDto.Token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(studentRequestStatusDto.TeacherEmail, new Guid(studentRequestStatusDto.Token)))
                return BadRequest();

            _studentService.UpdateStudentRequest(studentRequestStatusDto.StudentEmail,
                studentRequestStatusDto.Accepted, studentRequestStatusDto.Denied);

            if (studentRequestStatusDto.Accepted)
            {
                _teacherService.DecreaseTeacherAvailableSpots(studentRequestStatusDto.TeacherEmail);
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/student/comments/{email}/{token}")]
        public IActionResult GetTeacherComments(string email, string token)
        {
            if (!Token.CheckTokenFormat(token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            return Ok(_studentService.GetStudentComments(email));
        }

        [HttpGet]
        [Route("api/student/comments/{email}/{id}/{token}")]
        public IActionResult GetTeacherCommentReplies(string email, int id, string token)
        {
            if (!Token.CheckTokenFormat(token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            var commentReplies = new List<CommentReply>();
            var comments = _studentService.GetStudentComments(email).Where(c => c.Id == id);

            foreach (var comment in comments)
            {
                commentReplies.AddRange(_commentReplyService.GetCommentReplies(comment.Id));
            }

            return Ok(commentReplies);
        }

        [HttpPost]
        [Route("api/student/studentMeetingRequest")]
        public IActionResult AddStudentMeetingRequest([FromBody] RequestMeetingDto studentMeetingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!Token.CheckTokenFormat(studentMeetingDto.Token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(studentMeetingDto.StudentEmail, new Guid(studentMeetingDto.Token)))
                return BadRequest();

            var student = _studentService.GetStudentByEmail(studentMeetingDto.StudentEmail);
            var teacher = _teacherService.GetTeacherByEmail(studentMeetingDto.TeacherEmail);

            if (student != null && teacher != null)
            {
                _meetingRequestService.AddMeetingRequest(student.Id, teacher.Id, studentMeetingDto.Date.Value);
            }

            return Ok(student);
        }

        [HttpPost]
        [Route("api/student/deleteStudentMeetingRequest")]
        public IActionResult DeleteStudentMeetingRequest([FromBody] RequestMeetingDto studentMeetingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!Token.CheckTokenFormat(studentMeetingDto.Token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(studentMeetingDto.StudentEmail, new Guid(studentMeetingDto.Token)))
                return BadRequest();

            var student = _studentService.GetStudentByEmail(studentMeetingDto.StudentEmail);
            var teacher = _teacherService.GetTeacherByEmail(studentMeetingDto.TeacherEmail);

            if (student != null && teacher != null)
            {
                _meetingRequestService.DeleteMeetingRequest(student.Id, teacher.Id);
            }

            return Ok(student);
        }

        [HttpGet]
        [Route("api/student/studentMeetingRequest/{email}/{token}")]
        public IActionResult GetStudentMeetingRequest(string email, string token)
        {
            if (!Token.CheckTokenFormat(token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            var student = _studentService.GetStudentByEmail(email);
            var meetingRequestDto = new RequestMeetingDto();
            MeetingRequest meetingRequest = null;

            if (student != null)
            {
                meetingRequest = _meetingRequestService.GetStudentMeetingRequests(student.Id);
            }

            if (meetingRequest != null)
            {
                meetingRequestDto.Date = meetingRequest.Date;
                meetingRequestDto.StudentEmail = _studentService.GetStudentById(meetingRequest.StudentId.Value).Email;
                meetingRequestDto.TeacherEmail = _teacherService.GetTeacherById(meetingRequest.TeacherId.Value).Email;
            }

            return Ok(meetingRequestDto);
        }

        [HttpGet]
        [Route("api/student/studentMeetingRequestStatus/{email}/{token}")]
        public IActionResult GetStudentMeetingRequestStatus(string email, string token)
        {
            if (!Token.CheckTokenFormat(token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            var student = _studentService.GetStudentByEmail(email);
            var requestMeetingStatusDto = new RequestMeetingStatusDto();
            MeetingRequest meetingRequest = null;

            if (student != null)
            {
                meetingRequest = _meetingRequestService.GetStudentMeetingRequests(student.Id);
            }

            if (meetingRequest != null)
            {
                requestMeetingStatusDto.Status = meetingRequest.Status;
            }

            return Ok(requestMeetingStatusDto);
        }


        [HttpPut]
        [Route("api/student/editStudent")]
        public IActionResult EditStudent([FromBody] EditStudentDto editStudentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!Token.CheckTokenFormat(editStudentDto.Token))
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(editStudentDto.Email, new Guid(editStudentDto.Token)))
                return BadRequest();

            _studentService.EditStudent(
                    new Student
                    {
                        Email = editStudentDto.Email,
                        GitUrl = editStudentDto.GitUrl,
                        Pending = editStudentDto.Pending,
                        StudentBachelorTheme = new BachelorTheme
                        {
                            Title = editStudentDto.BachelorThemeTitle,
                            Description = editStudentDto.BachelorThemeDescription
                        }
                    }
                );

            return Ok(new object());
        }
    }
}
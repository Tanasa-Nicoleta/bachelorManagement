using System.Collections.Generic;
using System.Linq;
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        public StudentController(IStudentService studentService,
            IBachelorThemeService bachelorThemeService,
            ICommentReplyService commentReplyService,
            ITeacherService teacherService,
            IMeetingRequestService meetingRequestService,
            ICommentService commentService)
        {
            _studentService = studentService;
            _bachelorThemeService = bachelorThemeService;
            _commentReplyService = commentReplyService;
            _teacherService = teacherService;
            _meetingRequestService = meetingRequestService;
            _commentService = commentService;
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

            _studentService.UpdateStudentRequest(studentRequestStatusDto.StudentEmail,
                studentRequestStatusDto.Accepted, studentRequestStatusDto.Denied);

            if (studentRequestStatusDto.Accepted)
            {
                _teacherService.DecreaseTeacherAvailableSpots(studentRequestStatusDto.TeacherEmail);
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/student/comments/{email}")]
        public IActionResult GetTeacherComments(string email)
        {
            return Ok(_studentService.GetStudentComments(email));
        }

        [HttpPost]
        [Route("api/student/comments/{email}")]
        public IActionResult AddStudentPost([FromBody] PostDto postDto)
        {
            var student = _studentService.GetStudentByEmail(postDto.StudentEmail);
            var teacher = _teacherService.GetTeacherByEmail(postDto.TeacherEmail);
            
            _commentService.AddComment(student?.Id, teacher?.Id, postDto.CommentContent, postDto.Date);

            return Ok();
        }

        [HttpGet]
        [Route("api/student/comments/{email}/{id}")]
        public IActionResult GetTeacherCommentReplies(string email, int id)
        {
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
        public IActionResult AddStudentMeetingRequest([FromBody] StudentMeetingRequestDto studentMeetingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = _studentService.GetStudentByEmail(studentMeetingDto.StudentEmail);
            var teacher = _teacherService.GetTeacherByEmail(studentMeetingDto.TeacherEmail);

            if (student != null && teacher != null)
            {
                _meetingRequestService.AddMeetingRequest(student.Id, teacher.Id, studentMeetingDto.Date);
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/student/studentMeetingRequest/{email}")]
        public IActionResult GetTeacherMeetingRequest(string email)
        {
            var student = _studentService.GetStudentByEmail(email);
            MeetingRequest meetingRequest = null;

            if (student != null)
            {
                meetingRequest = _meetingRequestService.GetStudentMeetingRequests(student.Id);
            }

            var meetingRequestDto = new StudentMeetingRequestDto
            {
                Date = meetingRequest.Date,
                StudentEmail = _studentService.GetStudentById(meetingRequest.StudentId.Value).Email,
                TeacherEmail = _teacherService.GetTeacherById(meetingRequest.TeacherId.Value).Email
            };

            return Ok(meetingRequestDto);
        }
    }
}
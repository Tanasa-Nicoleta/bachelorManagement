using System.Collections.Generic;
using System.Linq;
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BachelorManagement.DataLayer.Enums;
using System;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly ICommentReplyService _commentReplyService;
        private readonly ICommentService _commentService;
        private readonly IMeetingRequestService _meetingRequestService;
        private readonly IConsultationService _consultationService;
        private readonly IAccountService _accountService;

        public TeacherController(ITeacherService teacherService,
            ICommentReplyService commentReplyService,
            IMeetingRequestService meetingRequestService,
            IStudentService studentService,
            ICommentService commentService,
            IConsultationService consultationService,
            IAccountService accountService)
        {
            _teacherService = teacherService;
            _commentReplyService = commentReplyService;
            _meetingRequestService = meetingRequestService;
            _studentService = studentService;
            _commentService = commentService;
            _consultationService = consultationService;
            _accountService = accountService;
        }

        [HttpGet]
        [Route("api/teachers/{email}/{token}")]
        public IActionResult Get(string email, string token)
        {

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            return Ok(_teacherService.GetAllTeachers());
        }

        [HttpGet]
        [Route("api/teacher/{email}/{token}")]
        public IActionResult GetTeacher(string email, string token)
        {
            var t = token.Replace("\\", "");

            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            return Ok(_teacherService.GetTeacherByEmail(email));
        }

        [HttpGet]
        [Route("api/teacher/themes/{email}/{token}")]
        public IActionResult GetTeacherThemes(string email, string token)
        {
            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            return Ok(_teacherService.GetTeacherBachelorThemes(email));
        }

        [HttpGet]
        [Route("api/teacher/students/{email}/{token}")]
        public IActionResult GetTeacherStudents(string email, string token)
        {
            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            var students = _teacherService.GetTeacherStudents(email);
            List<StudentDto> studentDtos = new List<StudentDto>();

            foreach (var student in students)
            {
                studentDtos.Add(
                    new StudentDto
                    {
                        Email = student.Email,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        GitUrl = student.GitUrl,
                        Achievements = student.Achievements,
                        Accepted = student.Accepted,
                        Denied = student.Denied,
                        BachelorTheme = _studentService.GetStudentBachelorThemes(student.Email)
                    }
                );
            }

            return Ok(studentDtos);
        }

        [HttpPost]
        [Route("api/teacher/addDetails")]
        public IActionResult AddTeacherDetails([FromBody] TeacherDetailsDto teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_accountService.CheckTheTokenValidity(teacherDto.Email, new Guid(teacherDto.Token)))
                return BadRequest();

            _teacherService.AddDetailsToTeacher(teacherDto.Email, teacherDto.Requirement, teacherDto.NoOfAvailableSpots,
                teacherDto.ThemeTitle, teacherDto.ThemeDescription);

            return Ok();
        }

        [HttpGet]
        [Route("api/teacher/comments/{email}/{token}")]
        public IActionResult GetTeacherComments(string email, string token)
        {
            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            return Ok(_teacherService.GetTeacherComments(email));
        }

        [HttpGet]
        [Route("api/teacher/comments/{email}/{id}/{token}")]
        public IActionResult GetTeacherCommentReplies(string email, int id, string token)
        {
            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            var commentReplies = new List<CommentReply>();
            var comments = _teacherService.GetTeacherComments(email).Where(c => c.Id == id);

            foreach (var comment in comments)
            {
                commentReplies.AddRange(_commentReplyService.GetCommentReplies(comment.Id));
            }

            return Ok(commentReplies);
        }

        [HttpGet]
        [Route("api/teacher/studentMeetingRequest/{email}/{token}")]
        public IActionResult GetTeacherMeetingRequest(string email, string token)
        {
            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            var teacher = _teacherService.GetTeacherByEmail(email);
            var meetingRequestDto = new List<RequestMeetingDto>();
            List<MeetingRequest> meetingRequests = new List<MeetingRequest>();

            if (teacher != null)
            {
                meetingRequests = _meetingRequestService.GetTeacherMeetingRequests(teacher.Id);
            }

            foreach (var meetingRequest in meetingRequests)
            {
                meetingRequestDto.Add(
                    new RequestMeetingDto
                    {
                        Date = meetingRequest.Date,
                        StudentEmail = _studentService.GetStudentById(meetingRequest.StudentId.Value).Email,
                        TeacherEmail = _teacherService.GetTeacherById(meetingRequest.TeacherId.Value).Email
                    }
                );
            };

            return Ok(meetingRequestDto);
        }

        [HttpPost]
        [Route("api/teacher/acceptStudentMeetingRequest")]
        public IActionResult AcceptStudentMeetingRequest([FromBody] RequestMeetingDto meetingRequestDto)
        {

            if (!_accountService.CheckTheTokenValidity(meetingRequestDto.TeacherEmail, new Guid(meetingRequestDto.Token)))
                return BadRequest();

            var student = _studentService.GetStudentByEmail(meetingRequestDto.StudentEmail);
            MeetingRequest meetingRequest = new MeetingRequest();

            if (student != null)
            {
                meetingRequest = _meetingRequestService.GetStudentMeetingRequests(student.Id);
            }

            if (meetingRequest != null)
            {
                _meetingRequestService.UpdateMeetingRequestStatus(meetingRequest, MeetingRequestStatus.Accepted);
            }

            return Ok(student);
        }

        [HttpPost]
        [Route("api/teacher/declineStudentMeetingRequest")]
        public IActionResult DeclineStudentMeetingRequest([FromBody] RequestMeetingDto meetingRequestDto)
        {

            if (!_accountService.CheckTheTokenValidity(meetingRequestDto.TeacherEmail, new Guid(meetingRequestDto.Token)))
                return BadRequest();

            var student = _studentService.GetStudentByEmail(meetingRequestDto.StudentEmail);
            MeetingRequest meetingRequest = new MeetingRequest();

            if (student != null)
            {
                meetingRequest = _meetingRequestService.GetStudentMeetingRequests(student.Id);
            }

            if (meetingRequest != null)
            {
                _meetingRequestService.UpdateMeetingRequestStatus(meetingRequest, MeetingRequestStatus.Declined);
            }

            return Ok(new object());
        }

        [HttpPost]
        [Route("api/teacher/comments")]
        public IActionResult AddTeacherPost([FromBody] PostDto postDto)
        {
            if (_accountService.CheckTheTokenValidity(postDto.TeacherEmail, new Guid(postDto.Token)) || _accountService.CheckTheTokenValidity(postDto.StudentEmail, new Guid(postDto.Token)))
            {
                var student = _studentService.GetStudentByEmail(postDto.StudentEmail);
                var teacher = _teacherService.GetTeacherByEmail(postDto.TeacherEmail);

                _commentService.AddComment(student?.Id, teacher?.Id, postDto.CommentContent, DateTime.Now);

                return Ok(student);
            }

            return BadRequest();
        }


        [HttpPost]
        [Route("api/teacher/addCommentReply")]
        public IActionResult AddTeacherCommentReply([FromBody] CommentReplyDto commentReplyDto)
        {
            var comment = _commentService.GetCommentById(commentReplyDto.CommentId);

            _commentReplyService.AddCommentReply(commentReplyDto.CommentId, commentReplyDto.CommentContent);

            return Ok(comment);
        }


        [HttpGet]
        [Route("api/teacher/getConsultation/{email}/{token}")]
        public IActionResult GetTeacherConsultation(string email, string token)
        {
            if (!_accountService.CheckTheTokenValidity(email, new Guid(token)))
                return BadRequest();

            Consultation consultation = new Consultation();
            var teacher = _teacherService.GetTeacherByEmail(email);

            if (teacher != null)
            {
                consultation = _consultationService.GetTeacherConsultation(teacher.Id);
            }

            return Ok(consultation);
        }

        [HttpPost]
        [Route("api/teacher/removeConsultation")]
        public IActionResult RemoveTeacherConsultation([FromBody] ConsultationDto consultationDto)
        {
            if (!_accountService.CheckTheTokenValidity(consultationDto.TeacherEmail, new Guid(consultationDto.Token)))
                return BadRequest();

            Consultation consultation = new Consultation();
            var teacher = _teacherService.GetTeacherByEmail(consultationDto.TeacherEmail);

            if (teacher != null)
            {
                consultation = _consultationService.GetTeacherConsultation(teacher.Id);
            }

            _consultationService.RemoveConsultation(consultation);

            return Ok(consultation);
        }

        [HttpPost]
        [Route("api/teacher/addConsultation")]
        public IActionResult AddTeacherConsultation([FromBody] ConsultationDto consultationDto)
        {
            if (!_accountService.CheckTheTokenValidity(consultationDto.TeacherEmail, new Guid(consultationDto.Token)))
                return BadRequest();

            Consultation consultation = new Consultation();
            var teacher = _teacherService.GetTeacherByEmail(consultationDto.TeacherEmail);

            if (teacher != null)
            {
                _consultationService.AddConsultation(teacher.Id, (WeekDays)consultationDto.Day, consultationDto.Interval);
            }

            return Ok(consultation);
        }

        [HttpPut]
        [Route("api/teacher/editConsultation")]
        public IActionResult EditTeacherConsultation([FromBody] ConsultationDto consultationDto)
        {
            if (!_accountService.CheckTheTokenValidity(consultationDto.TeacherEmail, new Guid(consultationDto.Token)))
                return BadRequest();

            Consultation consultation = new Consultation();
            var teacher = _teacherService.GetTeacherByEmail(consultationDto.TeacherEmail);

            if (teacher != null)
            {
                consultation = _consultationService.GetTeacherConsultation(teacher.Id);
            }

            _consultationService.UpdateConsultation(
                    new Consultation
                    {
                        Day = (WeekDays)consultationDto.Day,
                        Interval = consultationDto.Interval,
                        TeacherId = consultation.TeacherId,
                        Id = consultation.Id
                    }
                );

            return Ok(consultation);
        }

    }
}
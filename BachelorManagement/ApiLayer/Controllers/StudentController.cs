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
        private readonly ITeacherService _teacherService;

        public StudentController(IStudentService studentService, 
            IBachelorThemeService bachelorThemeService,
            ICommentReplyService commentReplyService,
            ITeacherService teacherService)
        {
            _studentService = studentService;
            _bachelorThemeService = bachelorThemeService;
            _commentReplyService = commentReplyService;
            _teacherService = teacherService;
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
        public IActionResult UpdateStudentRequest([FromBody] StudentRequestStatusDto studentRequestStatusDto)
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
    }
}
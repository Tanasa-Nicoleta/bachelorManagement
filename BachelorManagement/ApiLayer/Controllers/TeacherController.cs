using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using BachelorManagement.ApiLayer.Models;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICommentReplyService _commentReplyService;

        public TeacherController(ITeacherService teacherService, 
            ICommentReplyService commentReplyService)
        {
            _teacherService = teacherService;
            _commentReplyService = commentReplyService;
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
    }
}
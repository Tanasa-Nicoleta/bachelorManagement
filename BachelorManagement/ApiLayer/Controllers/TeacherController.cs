using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
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
            return Ok(_teacherService.GetTeacher(email));
        }

        [HttpGet]
        [Route("api/teacher/themes/{email}")]
        public IActionResult GetTeacherThemes(string email)
        {
            return Ok(_teacherService.GetTeacherBachelorThemes(email));
        }
    }
}
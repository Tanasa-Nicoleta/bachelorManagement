using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BachelorManagement.ApiLayer.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
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

    }
}
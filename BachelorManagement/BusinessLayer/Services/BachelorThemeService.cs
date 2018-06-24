using System.Linq;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class BachelorThemeService : IBachelorThemeService
    {
        private readonly IRepository<BachelorTheme> _bachelorThemeRepository;
        private readonly IStudentService _studentService;

        public BachelorThemeService(IRepository<BachelorTheme> bachelorThemeRepository, IStudentService studentService)
        {
            _bachelorThemeRepository = bachelorThemeRepository;
            _studentService = studentService;
        }

        public void AddBachelorThemeToStudent(string email, string title, string description)
        {
            var student = _studentService.GetStudentByEmail(email);

            if (student != null)
            {
                var bachelorTheme = _bachelorThemeRepository.GetAll().FirstOrDefault(b => b.StudentId == student.Id);

                if (bachelorTheme == null)
                    _bachelorThemeRepository.Add(new BachelorTheme
                    {
                        Description = description,
                        StudentId = student.Id,
                        Title = title
                    });
            }
        }

        public BachelorTheme GetBachelorThemeByTeacherId(int teacherId)
        {
            return _bachelorThemeRepository.GetAll().FirstOrDefault(b => b.TeacherId == teacherId);           
        }
    }
}
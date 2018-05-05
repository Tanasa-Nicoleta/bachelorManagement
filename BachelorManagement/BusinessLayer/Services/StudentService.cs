using System.Collections.Generic;
using System.Linq;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class StudentService: IStudentService
    {
        private IRepository<Student> _studentRepository;
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IRepository<BachelorTheme> _bachelorThemeRepository;

        public StudentService(IRepository<Student> studentRepository, IRepository<Teacher> teacherRepository, IRepository<BachelorTheme> bachelorThemeRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _bachelorThemeRepository = bachelorThemeRepository;
        }

        public Student GetStudentByEmail(string email)
        {
            return _studentRepository.GetAll().FirstOrDefault(s =>
                string.Equals(s.Email.ToLower(), email.ToLower()));
        }

        public IEnumerable<BachelorTheme> GetStudentBachelorThemes(string email)
        {
            var student = GetStudentByEmail(email);
            var themes = GetStudentBacelorThemes(student);
            return new List<BachelorTheme>(themes);
        }

        public Teacher GetStudentsTeacher(string email)
        {
            var student = GetStudentByEmail(email);
            var teacher = GetStudentTeacher(student);
            return teacher;
        }

        private IEnumerable<BachelorTheme> GetStudentBacelorThemes(Student student)
        {
            return _bachelorThemeRepository.GetAll().Where(b => b.StudentId == student.Id);
        }

        private Teacher GetStudentTeacher(Student student)
        {
            return _teacherRepository.GetAll().FirstOrDefault(t => t.Id == student.TeacherId);
        }


    }
}

using System.Collections.Generic;
using System.Linq;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<BachelorTheme> _bachelorThemeRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(IRepository<Teacher> teacherRepository,
            IRepository<BachelorTheme> bachelorThemeRepository,
            IRepository<Student> studentRepository)
        {
            _teacherRepository = teacherRepository;
            _bachelorThemeRepository = bachelorThemeRepository;
            _studentRepository = studentRepository;
        }

        public IQueryable<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return _teacherRepository.GetAll().FirstOrDefault(t =>
                string.Equals(t.Email.ToLower(), email.ToLower()));
        }

        public ICollection<BachelorTheme> GetTeacherBachelorThemes(string email)
        {
            var teacher = GetTeacherByEmail(email);
            var themes = GetTeacherBacelorThemes(teacher);
            return new List<BachelorTheme>(themes);
        }

        public ICollection<Student> GetTeacherBachelorStudents(string email)
        {
            var teacher = GetTeacherByEmail(email);
            var students = GetTeacherStudents(teacher);
            return new List<Student>(students);
        }

        private IEnumerable<BachelorTheme> GetTeacherBacelorThemes(Teacher teacher)
        {
            return _bachelorThemeRepository.GetAll().Where(b => b.TeacherId == teacher.Id);
        }

        private IEnumerable<Student> GetTeacherStudents(Teacher teacher)
        {
            return _studentRepository.GetAll().Where(s => s.TeacherId == teacher.Id);
        }
    }
}
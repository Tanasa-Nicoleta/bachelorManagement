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
        private readonly ICommentService _commentService;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(IRepository<Teacher> teacherRepository,
            IRepository<BachelorTheme> bachelorThemeRepository,
            IRepository<Student> studentRepository,
            ICommentService commentService)
        {
            _teacherRepository = teacherRepository;
            _bachelorThemeRepository = bachelorThemeRepository;
            _studentRepository = studentRepository;
            _commentService = commentService;
        }

        public IQueryable<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetTeacherByEmail(string email)
        {
            if(email == null)
                return null;

            return _teacherRepository.GetAll().FirstOrDefault(t =>
                string.Equals(t.Email.ToLower(), email.ToLower()));
        }

        public ICollection<BachelorTheme> GetTeacherBachelorThemes(string email)
        {
            var teacher = GetTeacherByEmail(email);
            var themes = GetTeacherBacelorThemes(teacher);

            return new List<BachelorTheme>(themes);
        }

        public ICollection<Student> GetTeacherStudents(string email)
        {
            var teacher = GetTeacherByEmail(email);
            var students = GetTeacherStudents(teacher);

            return new List<Student>(students);
        }

        public void AddDetailsToTeacher(string email, string requirement, int numberOfSpots, string themeTitle,
            string themeDescr)
        {
            var teacher = GetTeacherByEmail(email);

            if (teacher != null)
            {
                teacher.Requirement = requirement;
                teacher.NumberOfSpots = numberOfSpots;
                AddBachelorThemeToTeacher(teacher.Email, themeTitle, themeDescr);
            }

            _teacherRepository.Update(teacher);
        }

        public ICollection<Comment> GetTeacherComments(string email)
        {
            ICollection<Comment> comments = null;
            var teacher = GetTeacherByEmail(email);

            if (teacher != null) comments = _commentService.GetTeacherComments(teacher.Email);

            return comments;
        }

        public void DecreaseTeacherAvailableSpots(string email)
        {
            var teacher = GetTeacherByEmail(email);

            teacher.NumberOfAvailableSpots--;

            _teacherRepository.Update(teacher);
        }

        private void AddBachelorThemeToTeacher(string email, string title, string description)
        {
            var teacher = GetTeacherByEmail(email);

            if (teacher != null)
                teacher.BachelorThemes = new List<BachelorTheme>
                {
                    new BachelorTheme
                    {
                        Description = description,
                        Title = title,
                        TeacherId = teacher.Id
                    }
                };
        }

        private IEnumerable<BachelorTheme> GetTeacherBacelorThemes(Teacher teacher)
        {
            return _bachelorThemeRepository.GetAll().Where(b => b.TeacherId == teacher.Id);
        }

        private IEnumerable<Student> GetTeacherStudents(Teacher teacher)
        {
            return _studentRepository.GetAll().Where(s => s.TeacherId == teacher.Id);
        }

        public Teacher GetTeacherById(int id)
        {
            return _teacherRepository.GetAll().FirstOrDefault(t => t.Id == id);
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.Add(teacher);
        }

        public void RemoveTeacher(string email)
        {
            var teacher = GetTeacherByEmail(email);

            if(teacher != null)
            {
                _teacherRepository.Delete(teacher);
            }
        }
    }
}
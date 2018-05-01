using System.Collections.Generic;
using System.Linq;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public IQueryable<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetTeacher(string email)
        {
            return _teacherRepository.GetAll().FirstOrDefault(t =>
                string.Equals(t.Email.ToLower(), email.ToLower()));
        }

        public ICollection<BachelorTheme> GetTeacherBachelorThemes(string email)
        {
            var teacher = _teacherRepository.GetAll().FirstOrDefault(t =>
                string.Equals(t.Email.ToLower(), email.ToLower()));
            return teacher?.BachelorThemes;
        }
    }
}
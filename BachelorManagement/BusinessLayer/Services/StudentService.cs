﻿using System.Linq;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<BachelorTheme> _bachelorThemeRepository;
        private readonly IRepository<Mean> _meanRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Teacher> _teacherRepository;

        public StudentService(IRepository<Student> studentRepository, IRepository<Teacher> teacherRepository,
            IRepository<BachelorTheme> bachelorThemeRepository, IRepository<Mean> meanRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _bachelorThemeRepository = bachelorThemeRepository;
            _meanRepository = meanRepository;
        }

        public Student GetStudentByEmail(string email)
        {
            return _studentRepository.GetAll().FirstOrDefault(s =>
                string.Equals(s.Email.ToLower(), email.ToLower()));
        }

        public BachelorTheme GetStudentBachelorThemes(string email)
        {
            var student = GetStudentByEmail(email);
            var theme = GetStudentBacelorThemes(student);
            return theme;
        }

        public Teacher GetStudentsTeacher(string email)
        {
            var student = GetStudentByEmail(email);
            var teacher = GetStudentTeacher(student);
            return teacher;
        }

        public Mean GetStudentMeans(string email)
        {
            var student = GetStudentByEmail(email);
            var mean = GetStudentMean(student);
            return mean;
        }

        public void AddAchievementToStudent(string email, string achievement)
        {
            var student = GetStudentByEmail(email);
            student.Achievements = achievement;
            _studentRepository.Update(student);
        }

        public void UpdateStudentRequest(string email, bool accepted, bool denied)
        {
            var student = GetStudentByEmail(email);
            if (student != null)
            {
                student.Accepted = accepted;
                student.Denied = denied;
            }

            _studentRepository.Update(student);
        }

        private BachelorTheme GetStudentBacelorThemes(Student student)
        {
            return _bachelorThemeRepository.GetAll().FirstOrDefault(b => b.StudentId == student.Id);
        }

        private Teacher GetStudentTeacher(Student student)
        {
            return _teacherRepository.GetAll().FirstOrDefault(t => t.Id == student.TeacherId);
        }

        private Mean GetStudentMean(Student student)
        {
            return _meanRepository.GetAll().FirstOrDefault(m => m.StudentId == student.Id);
        }
    }
}
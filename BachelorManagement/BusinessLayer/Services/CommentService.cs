using System.Collections.Generic;
using System.Linq;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Teacher> _teacherRepository;

        public CommentService(IRepository<Comment> commentRepository,
            IRepository<Teacher> teacherRepository,
            IRepository<Student> studentRepository)
        {
            _commentRepository = commentRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public ICollection<Comment> GetStudentComments(string email)
        {
            return _commentRepository.GetAll().Where(c => c.Student.Email == email).ToList();
        }

        public ICollection<Comment> GetTeacherComments(string email)
        {
            return _commentRepository.GetAll().Where(c => c.Teacher.Email == email).ToList();
        }

        public ICollection<CommentReply> GetTeacherCommentReplies(string email, int commentId)
        {
            var teacher = GetTeacherByEmail(email);
            ICollection<CommentReply> commentReplies = null;
            if (teacher != null) commentReplies = GetTeacherCommentReplies(teacher.Email, commentId);

            return commentReplies;
        }

        public ICollection<CommentReply> GetStudentCommentReplies(string email, int commentId)
        {
            var student = GetStudentByEmail(email);
            ICollection<CommentReply> commentReplies = null;
            if (student != null) commentReplies = GetStudentCommentReplies(student.Email, commentId);

            return commentReplies;
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return _teacherRepository.GetAll().FirstOrDefault(t =>
                string.Equals(t.Email.ToLower(), email.ToLower()));
        }

        public Student GetStudentByEmail(string email)
        {
            return _studentRepository.GetAll().FirstOrDefault(s =>
                string.Equals(s.Email.ToLower(), email.ToLower()));
        }
    }
}
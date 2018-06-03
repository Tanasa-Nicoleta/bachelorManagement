using System;
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

        public CommentService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void AddComment(int? studentId, int? teacherId, string commentContent, DateTime date)
        {
            _commentRepository.Add(new Comment
            {
                TeacherId = teacherId == null ? null : teacherId,
                StudentId = studentId == null ? null : studentId,
                CommentContent = commentContent,
                Date = date
            }
            );
        }

        public Comment GetCommentById(int commentId)
        {
            return _commentRepository.GetAll().FirstOrDefault(c => c.Id == commentId);
        }

        public ICollection<Comment> GetStudentComments(string email)
        {
            return _commentRepository.GetAll().Where(c => c.Student.Email == email).ToList();
        }

        public ICollection<Comment> GetTeacherComments(string email)
        {
            return _commentRepository.GetAll().Where(c => c.Teacher.Email == email).ToList();
        }

    }
}
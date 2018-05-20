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
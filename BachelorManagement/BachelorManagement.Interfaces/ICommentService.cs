using System.Collections.Generic;
using BachelorManagement.DataLayer.Entities;
using System;

namespace BachelorManagement.Interfaces
{
    public interface ICommentService
    {
        ICollection<Comment> GetTeacherComments(string email);

        ICollection<Comment> GetStudentComments(string email);

        void AddComment(int? studentId, int? teacherId, string commentContent, DateTime date);
    }
}
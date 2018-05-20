using System.Collections.Generic;
using BachelorManagement.DataLayer.Entities;

namespace BachelorManagement.Interfaces
{
    public interface ICommentService
    {
        ICollection<Comment> GetTeacherComments(string email);

        ICollection<Comment> GetStudentComments(string email);
    }
}
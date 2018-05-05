using System.Collections.Generic;
using BachelorManagement.DataLayer.Entities;

namespace BachelorManagement.Interfaces
{
    public interface IStudentService
    {
        Teacher GetStudentsTeacher(string email);
        Student GetStudentByEmail(string email);
        IEnumerable<BachelorTheme> GetStudentBachelorThemes(string email);
    }
}

using System.Collections.Generic;
using System.Linq;
using BachelorManagement.DataLayer.Entities;

namespace BachelorManagement.Interfaces
{
    public interface ITeacherService
    {
        IQueryable<Teacher> GetAllTeachers();

        Teacher GetTeacher(string email);

        ICollection<BachelorTheme> GetTeacherBachelorThemes(string email);

        ICollection<Student> GetTeacherBachelorStudents(string email);
    }
}
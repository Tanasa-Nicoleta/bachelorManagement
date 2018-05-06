using System.Collections.Generic;
using System.Linq;
using BachelorManagement.DataLayer.Entities;

namespace BachelorManagement.Interfaces
{
    public interface ITeacherService
    {
        IQueryable<Teacher> GetAllTeachers();

        Teacher GetTeacherByEmail(string email);

        ICollection<BachelorTheme> GetTeacherBachelorThemes(string email);

        ICollection<Student> GetTeacherStudents(string email);

        void AddDetailsToTeacher(string email, string requirement, int numberOfSpots, string themeTitle, string themeDescr);
    }
}
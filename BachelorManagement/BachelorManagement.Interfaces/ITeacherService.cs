using System.Collections.Generic;
using System.Linq;
using BachelorManagement.DataLayer.Entities;

namespace BachelorManagement.Interfaces
{
    public interface ITeacherService
    {
        IQueryable<Teacher> GetAllTeachers();
        Teacher GetTeacherByEmail(string email);
        Teacher GetTeacherById(int id);
        ICollection<BachelorTheme> GetTeacherBachelorThemes(string email);
        ICollection<Student> GetTeacherStudents(string email);
        ICollection<Comment> GetTeacherComments(string email);
        void AddDetailsToTeacher(string email, string requirement, int numberOfSpots, string themeTitle,
            string themeDescr);
        void DecreaseTeacherAvailableSpots(string email);
        void AddTeacher(Teacher teacher);
        void EditTeacher(Teacher teacher);
        void RemoveTeacher(string email);
    }
}
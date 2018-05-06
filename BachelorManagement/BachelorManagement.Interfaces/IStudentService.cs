using BachelorManagement.DataLayer.Entities;

namespace BachelorManagement.Interfaces
{
    public interface IStudentService
    {
        Teacher GetStudentsTeacher(string email);
        Student GetStudentByEmail(string email);
        BachelorTheme GetStudentBachelorThemes(string email);
        Mean GetStudentMeans(string email);
        void AddAchievementToStudent(string email, string achievement);
        void UpdateStudentRequest(string email, bool accepted, bool denied);
    }
}
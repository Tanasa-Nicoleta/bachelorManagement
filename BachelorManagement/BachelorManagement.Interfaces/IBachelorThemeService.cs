namespace BachelorManagement.Interfaces
{
    public interface IBachelorThemeService
    {
        void AddBachelorThemeToStudent(string email, string title, string description);
    }
}

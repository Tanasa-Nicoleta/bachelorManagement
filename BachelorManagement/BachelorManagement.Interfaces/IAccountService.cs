namespace BachelorManagement.Interfaces
{
    public interface IAccountService
    {
        bool CheckIfAccountExists(string username, string password);
        bool CheckIfUserNameExists(string username);
        bool AddNewUser(string username, string password);
    }
}
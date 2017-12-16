namespace BachelorManagement.Interfaces
{
    public interface IAccountService
    {
        bool CheckIfAccountExists(string username, string password);
    }
}

using System;

namespace BachelorManagement.Interfaces
{
    public interface IAccountService
    {
        bool CheckIfAccountExists(string username, string password);
        bool CheckIfUserNameExists(string username);
        bool AddNewUser(string username, string password);
        bool IsTeacher(string username);
        Guid? GetAccesToken(string username);
        Guid AddAccesToken(string username); 
        bool CheckTheTokenValidity(string username, Guid token);
    }
}
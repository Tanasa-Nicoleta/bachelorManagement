using BachelorManagement.BusinessLayer.Contracts.Enums;
using BachelorManagement.DataLayer;

namespace BachelorManagement.BusinessLayer.Contracts
{
    public class User : IEntityBase
    {
        public UserType UserType;
        public string Email { get; set; }

        public string Password { get; set; }
        public int Id { get; set; }
    }
}
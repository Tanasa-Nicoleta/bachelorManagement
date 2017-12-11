using BusinessLayer.Interfaces;

namespace DataLayer.Entities
{
    public class User : IEntityBase
    {
        public UserType UserType;
        public string Email { get; set; }

        public string Password { get; set; }
        public int Id { get; set; }
    }
}
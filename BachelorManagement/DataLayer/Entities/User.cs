using BachelorManagement.DataLayer.Enums;
using System;

namespace BachelorManagement.DataLayer.Entities
{
    public class User : IEntityBase
    {
        public Guid Token { get; set;}
        public UserType UserType { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
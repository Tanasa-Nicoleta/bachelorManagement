﻿using BusinessLayer.Interfaces;

namespace BusinessLayer.Contracts
{
    public class User: IEntityBase
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public int Id { get; set; }
    }
}
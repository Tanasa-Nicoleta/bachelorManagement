﻿using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Student : IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SerialNumber { get; set; }
        public string StartYear { get; set; }
        public int MeanId { get; set; }
        public int TeacherId { get; set; }
        public int FileId { get; set; }
        public Mean Mean { get; set; }
        public Teacher Teacher { get; set; }
        public File File { get; set; }
        public int Id { get; set; }
    }
}
using System;
using BachelorManagement.BusinessLayer.Interfaces;

namespace BachelorManagement.DataLayer.Entities
{
    public class Announcement : IEntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int TeacherId { get; set; }

        public DateTime Date { get; set; }
        public Teacher Teacher { get; set; }
        public int Id { get; set; }
    }
}
﻿using System;
using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Announcement : IEntityBase
    {
        public string Ttile { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Teacher Teacher { get; set; }
        public int Id { get; set; }
    }
}
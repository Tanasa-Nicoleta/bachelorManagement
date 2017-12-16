﻿using System.Collections.Generic;
using BachelorManagement.BusinessLayer.Interfaces;

namespace BachelorManagement.DataLayer.Entities
{
    public class Session : IEntityBase
    {
        public ICollection<Year> Years { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int Id { get; set; }
    }
}
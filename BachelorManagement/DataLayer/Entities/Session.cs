using System.Collections.Generic;
using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Session : IEntityBase
    {
        public ICollection<Year> Years { get; set; }
        public Teacher Teacher { get; set; }
        public int Id { get; set; }
    }
}
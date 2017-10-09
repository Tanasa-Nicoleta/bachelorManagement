using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class FileContent : IEntityBase
    {
        public string Content { get; set; } // research best type later
        public int FileId { get; set; }
        public File File { get; set; }
        public int Id { get; set; }
    }
}
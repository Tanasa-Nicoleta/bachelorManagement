using BachelorManagement.BusinessLayer.Interfaces;

namespace BachelorManagement.DataLayer.Entities
{
    public class FileContent : IEntityBase
    {
        public byte[] Content { get; set; } // research best type later
        public int FileId { get; set; }
        public File File { get; set; }
        public int Id { get; set; }
    }
}
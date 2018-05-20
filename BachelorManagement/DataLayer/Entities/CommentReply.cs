using System;

namespace BachelorManagement.DataLayer.Entities
{
    public class CommentReply : IEntityBase
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public string CommentReplyContent { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}
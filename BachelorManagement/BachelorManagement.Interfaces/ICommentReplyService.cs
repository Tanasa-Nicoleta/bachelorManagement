using System.Collections.Generic;
using BachelorManagement.DataLayer.Entities;

namespace BachelorManagement.Interfaces
{
    public interface ICommentReplyService
    {
        ICollection<CommentReply> GetCommentReplies(int commentId);
        void AddCommentReply(int commentId, string commentContent);
    }
}
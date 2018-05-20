using System;
using System.Collections.Generic;
using System.Linq;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.Interfaces;

namespace BachelorManagement.BusinessLayer.Services
{
    public class CommentReplyService : ICommentReplyService
    {
        private readonly IRepository<CommentReply> _commentReplyRepository;

        public CommentReplyService(IRepository<CommentReply> commentReplyRepository)
        {
            _commentReplyRepository = commentReplyRepository;
        }

        public ICollection<CommentReply> GetCommentReplies(int commentId)
        {
            return _commentReplyRepository.GetAll().Where(c => c.CommentId == commentId).ToList();
        }

        public void AddCommentReply(int commentId, string commentContent)
        {
            _commentReplyRepository.Add(new CommentReply
            {
                CommentId = commentId,
                CommentReplyContent = commentContent,
                Date = DateTime.Now
            });
        }
    }
}
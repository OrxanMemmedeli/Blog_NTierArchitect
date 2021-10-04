using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll(int id)
        {
            return _commentDal.GetAll(x => x.BlogID == id);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }
    }
}

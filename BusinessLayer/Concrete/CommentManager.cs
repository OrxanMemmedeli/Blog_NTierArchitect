using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public void Add(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void Delete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> Filter)
        {
            return _commentDal.GetAll(Filter);
        }

        public List<Comment> GetAllWithBlog()
        {
            return _commentDal.GetAllWithBlog();
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public void Update(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}

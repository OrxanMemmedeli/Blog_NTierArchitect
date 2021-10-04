using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    interface ICommentService
    {
        void CommentAdd(Comment t);
        //void CategoryUpdate(Comment t);
        //void CategoryDelete(Comment t);
        List<Comment> GetAll();

        List<Comment> GetAll(int id);
        //Comment GetById(int id);
    }
}

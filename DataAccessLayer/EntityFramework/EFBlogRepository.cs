using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetAllWithRelationships()
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetAllWithRelationshipsByWriter(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).Where(x => x.WriterID == id).ToList();
            }
        }

        public List<Blog> GetLastBlogs(int count)
        {
            using (var cx = new BlogContext())
            {
                return cx.Blogs.OrderByDescending(x => x.CreatedDate).Take(count).ToList();
            }
        }

        public List<Blog> GetAllWithCategoryAndComments()
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).Include(x => x.Comments).ToList();
            }
        }


        public List<Blog> GetAllWithCategoryAndComments(Expression<Func<Blog, bool>> filter)
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).Include(x => x.Comments).Where(filter).ToList();
            }
        }

        public Blog GetByIDWithComments(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Comments).Include(x => x.Category).SingleOrDefault(x => x.ID == id);
            }
        }

        public List<Blog> SerachData(List<Blog> blogs, string data)
        {
            var list = new List<Blog>();
            if (!string.IsNullOrEmpty(data))
            {
                foreach (var item in blogs)
                {
                    var blog = item.Title.Contains(data) == false ? item.Content.Contains(data) == false ? null : item : item;
                    if (blog != null)
                    {
                        list.Add(blog);
                    }
                }
                //blogs = blogs.Where(x => x.Title.Contains(data)) == null ? blogs.Where(x => x.Content.Contains(data)).ToList() : blogs.Where(x => x.Title.Contains(data)).ToList();
                return list;
            }

            return blogs;
        }
    }
}

using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect
{
    public static class ServiceInjector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<IAboutService, AboutManager>().AddTransient<IAboutDal, EFAboutRepository>();
            services.AddTransient<IAdminService, AdminManager>().AddTransient<IAdminDal, EFAdminRepository>();
            services.AddTransient<IBlogService, BlogManager>().AddTransient<IBlogDal, EFBlogRepository>();
            services.AddTransient<ICategoryService, CategoryManager>().AddTransient<ICategoryDal, EFCategoryRepository>();
            services.AddTransient<ICommentService, CommentManager>().AddTransient<ICommentDal, EFCommentRepository>();
            services.AddTransient<IContactService, ContactManager>().AddTransient<IContactDal, EFContactRepository>();
            services.AddTransient<IMessageService, MessageManager>().AddTransient<IMessageDal, EFMessageRepository>();
            services.AddTransient<INewsLetterService, NewsLetterManager>().AddTransient<INewsLetterDal, EFNewsLetterRepository>();
            services.AddTransient<INotificationService, NotificationManager>().AddTransient<INotificationDal, EFNotificationRepository>();
        }
    }
}

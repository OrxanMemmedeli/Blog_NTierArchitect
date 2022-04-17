using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
namespace Blog_NTierArchitect.Models.ViewModels
{
    public class CommentViewModel
    {
        [Required(ErrorMessage = "Ad boş ola bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Başlıq boş ola bilməz")] 
        public string Title { get; set; }
        [Required(ErrorMessage = "Mesaj boş ola bilməz")] 
        public string Content { get; set; }
        [Range(1, 10, ErrorMessage = "Daxil edilmiş dəyər 1-10 arasında ola bilər)")]
        public int Score { get; set; } = 1;
        public int BlogID { get; set; }

        public static implicit operator CommentViewModel(Comment model)
        {
            return new CommentViewModel
            {
                UserName = model.UserName,
                Title = model.Title,
                Content = model.Content,
                Score = model.Score,
                BlogID = model.BlogID,
            };
        }

        public static implicit operator Comment(CommentViewModel model)
        {
            return new Comment
            {
                UserName = model.UserName,
                Title = model.Title,
                Content = model.Content,
                Score = model.Score,
                BlogID = model.BlogID,
            };
        }
    }
}

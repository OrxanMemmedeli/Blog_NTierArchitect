using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class BlogDetailsScoreViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            using (var cx = new BlogContext())
            {
                return View(cx.BlogScores.FirstOrDefault(x => x.BlogID == id));
            }
        }
    }
}

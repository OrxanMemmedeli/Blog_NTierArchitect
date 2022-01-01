using Blog_NTierArchitect.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blog_NTierArchitect.Areas.Admin.ViewComponents.Widgets
{
    public class WidgetThirdRowViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string today = DateTime.Now.ToString("dd.MM.yyyy");
            string url = "https://www.cbar.az/currencies/" + today + ".xml";

            XDocument document = XDocument.Load(url);
            List<CbarViewModel> list = new List<CbarViewModel>();

            var xmlList = document.Descendants("Valute");

            foreach (var item in xmlList)
            {
                if (
                    item.Attribute("Code").Value == "XPT" || 
                    item.Attribute("Code").Value == "XAG" || 
                    item.Attribute("Code").Value == "XAU" || 
                    item.Attribute("Code").Value == "USD" || 
                    item.Attribute("Code").Value == "EUR" || 
                    item.Attribute("Code").Value == "TRY")
                {
                    CbarViewModel model = new CbarViewModel();
                    model.Name = item.Descendants("Name").ElementAt(0).Value;
                    model.Value = item.Descendants("Value").ElementAt(0).Value;
                    model.Code = item.Attribute("Code").Value;
                    list.Add(model);
                }
            }

            ViewBag.Description = document.Descendants("ValCurs").ElementAt(0).Attribute("Description").Value;
            return View(list);
        }
    }
}

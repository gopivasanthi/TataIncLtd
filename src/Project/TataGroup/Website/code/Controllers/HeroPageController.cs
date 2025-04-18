using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tata.Project.TataGroupWeb.Models;

namespace Tata.Project.TataGroupWeb.Controllers
{
    public class HeroPageController : Controller
    {
        // GET: HeroPage
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            HeroPage heroPage = new HeroPage()
            {
                HeroIntro = new HtmlString(FieldRenderer.Render(contextItem, "PageIntro")),
                HeroDescription = new HtmlString(FieldRenderer.Render(contextItem, "PageDescription")),
                HeroBackgroundImage = new HtmlString(FieldRenderer.Render(contextItem, "PageBackgroundImage"))
            };

            return View("~/Views/Tata/HeroPage/Index.cshtml", heroPage);
        }
    }
}
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tata.Project.TataGroupWeb.Models;

namespace Tata.Project.TataGroupWeb.Controllers
{
    public class FeaturedHeroController : Controller
    {
        // GET: FeaturedHero
        public ActionResult Index()
        {
            var renderingItem = RenderingContext.Current.ContextItem;
            HeroPage heroPage = new HeroPage()
            {
                HeroIntro = new HtmlString(FieldRenderer.Render(renderingItem, "PageIntro")),
                HeroDescription = new HtmlString(FieldRenderer.Render(renderingItem, "PageDescription")),
                HeroBackgroundImage = new HtmlString(FieldRenderer.Render(renderingItem, "PageBackgroundImage"))
            };

            return View("~/Views/Tata/HeroPage/Index.cshtml", heroPage);
        }
    }
}
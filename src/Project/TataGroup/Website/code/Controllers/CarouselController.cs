using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tata.Project.TataGroupWeb.Models;

namespace Tata.Project.TataGroupWeb.Controllers
{
    public class CarouselController : Controller
    {
        // GET: Carousel
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            var carouselItems = contextItem.Children
                                    .Where(x => x.Template.Name != "Settings")
                                    .Select(page => new CarouselItem
                                    {
                                        CarouselTitle = new HtmlString(FieldRenderer.Render(page, "CarouselTitle")),
                                        CarouselDescription = new HtmlString(FieldRenderer.Render(page, "CarouselDescription")),
                                        CarouselImage = new HtmlString(FieldRenderer.Render(page, "CarouselImage", "class='d-block w-100'")),
                                        CarouselUrl = LinkManager.GetItemUrl(page)
                                    });
            return View("~/Views/Tata/Home/Carousel.cshtml", carouselItems);
        }
    }
}
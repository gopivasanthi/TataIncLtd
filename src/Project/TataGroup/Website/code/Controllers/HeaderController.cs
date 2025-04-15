using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tata.Project.TataGroupWeb.Models;

namespace Tata.Project.TataGroupWeb.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header
        public ActionResult Index()
        {
            var rederingContextItem = RenderingContext.Current.ContextItem;
            var headerTitle = rederingContextItem.Fields["HeaderTitle"].Value;
            ImageField headerLogo = rederingContextItem.Fields["HeaderLogo"];
            MultilistField headerNavigationItems = rederingContextItem.Fields["HeaderNavigationItems"];
            var headerNavItems = headerNavigationItems
                                    .GetItems()
                                    .Select(x => new NavigationItem
                                    {
                                        DisplayName = x.Fields["PageIntro"].Value,
                                        NavigationUrl = LinkManager.GetItemUrl(x)
                                    }).ToList();
            TataImage imageItem = new TataImage()
            {
                ImageUrl = MediaManager.GetMediaUrl(headerLogo.MediaItem),
                ImageAlt = headerLogo.Alt
            };
            HeaderNavigation headerNavigation = new HeaderNavigation()
            {
                HeaderTitle = headerTitle,
                HeaderLogo = imageItem,
                HeaderNavigationItems = headerNavItems
            };
            return View("~/Views/Tata/Header/Index.cshtml", headerNavigation);
        }
    }
}
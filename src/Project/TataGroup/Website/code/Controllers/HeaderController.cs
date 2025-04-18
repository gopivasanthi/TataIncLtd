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
            var currentContextItem = Sitecore.Context.Item;
            var rootPath = Sitecore.Context.Site.StartPath;
            var contextDatabase = Sitecore.Context.Database;
            var homeItem = contextDatabase.GetItem(rootPath);
            NavigationItem headerHomeNavigation = new NavigationItem()
            {
                DisplayName = rederingContextItem.Fields["HeaderTitle"].Value,
                NavigationUrl = LinkManager.GetItemUrl(homeItem),
                IsCurrentItem = homeItem.ID == currentContextItem.ID
            };
            ImageField headerLogo = rederingContextItem.Fields["HeaderLogo"];
            MultilistField headerNavigationItems = rederingContextItem.Fields["HeaderNavigationItems"];
            var headerNavItems = headerNavigationItems
                                    .GetItems()
                                    .Select(x => new NavigationItem
                                    {
                                        DisplayName = x.Fields["PageIntro"].Value,
                                        NavigationUrl = LinkManager.GetItemUrl(x),
                                        IsCurrentItem = x.ID == currentContextItem.ID
                                    }).ToList();
            if (headerLogo != null && headerNavigationItems != null)
            {
                TataImage imageItem = new TataImage()
                {
                    ImageUrl = MediaManager.GetMediaUrl(headerLogo.MediaItem),
                    ImageAlt = headerLogo.Alt
                };
                HeaderNavigation headerNavigation = new HeaderNavigation()
                {
                    HeaderTitle = headerHomeNavigation,
                    HeaderLogo = imageItem,
                    HeaderNavigationItems = headerNavItems
                };
                return View("~/Views/Tata/Header/Index.cshtml", headerNavigation);
            }
            HeaderNavigation headerNavigationEmpty = new HeaderNavigation()
            {
                HeaderTitle = headerHomeNavigation,
                HeaderLogo = new TataImage(),
                HeaderNavigationItems = new List<NavigationItem>()
            };
            return View("~/Views/Tata/Header/Index.cshtml", headerNavigationEmpty);
        }
    }
}
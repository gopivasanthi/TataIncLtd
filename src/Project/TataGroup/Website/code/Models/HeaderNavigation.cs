using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tata.Project.TataGroupWeb.Models
{
    public class HeaderNavigation
    {
        public string HeaderTitle { get; set; }
        public TataImage HeaderLogo { get; set; }
        public List<NavigationItem> HeaderNavigationItems { get; set; }
    }
}
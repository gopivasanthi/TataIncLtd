using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tata.Project.TataGroupWeb.Models
{
    public class CarouselItem
    {
        public HtmlString CarouselImage { get; set; }
        public HtmlString CarouselTitle { get; set; }
        public HtmlString CarouselDescription { get; set; }
        public string CarouselUrl { get; set; }
    }
}
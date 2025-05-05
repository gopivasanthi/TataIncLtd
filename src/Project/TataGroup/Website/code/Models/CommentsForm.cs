using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tata.Project.TataGroupWeb.Models
{
    public class CommentsForm
    {
        public HtmlString UserNameLabel { get; set; }
        public HtmlString GenderLabel { get; set; }
        public HtmlString CommentsLabel { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Comment { get; set; }
    }
}
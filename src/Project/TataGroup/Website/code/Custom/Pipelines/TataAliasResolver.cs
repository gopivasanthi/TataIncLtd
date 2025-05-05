using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tata.Project.TataGroupWeb.Custom.Pipelines
{
    public class TataAliasResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            if (Sitecore.Context.Item != null)
                return;
            if (Sitecore.Context.Database == null)
                return;
            if (args.Url.ItemPath.Length == 0)
                return;

            //args.Url.FilePath

            var startPath = "/sitecore/content/tataalias";
            var parentItem = Sitecore.Context.Database.GetItem(startPath);
            if (parentItem == null)
                return;
            var resultItem = parentItem?
                                .Children?
                                .Where(x => x.Name == args.Url.FilePath.Split('/')[1])?
                                .FirstOrDefault();

            if (resultItem != null)
                Sitecore.Context.Item = resultItem;
            return;
        }
    }
}
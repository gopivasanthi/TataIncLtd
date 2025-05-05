using Sitecore.Publishing;
using Sitecore.SecurityModel;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tata.Project.TataGroupWeb.Models;

namespace Tata.Project.TataGroupWeb.Controllers
{
    public class TataCommentsFormController : Controller
    {
        
        // GET: TataCommentsForm
        public ActionResult Index()
        {
            var commentsFormItem = Sitecore.Context.Database.GetItem(SitecoreItemConstants.CommentsForm);
            var commentsForm = new CommentsForm()
            {
                UserNameLabel = new HtmlString(FieldRenderer.Render(commentsFormItem, "UserNameLabel")),
                GenderLabel = new HtmlString(FieldRenderer.Render(commentsFormItem, "GenderLabel")),
                CommentsLabel = new HtmlString(FieldRenderer.Render(commentsFormItem, "CommentsLabel")),
                UserName = string.Empty,
                Gender = string.Empty,
                Comment = string.Empty
            };
            return View("~/Views/Tata/Forms/TataCommentsForm.cshtml", commentsForm);
        }
        [HttpPost]
        public ActionResult Index(CommentsForm commentsForm)
        {
            //store the comment in the database
            //master database
            var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
            var webDb = Sitecore.Configuration.Factory.GetDatabase("web");
            //parentitem (renderingitem)
            var contextItem = Sitecore.Context.Item;
            var contextItemFromMaster = masterDb.GetItem(contextItem.ID);
            //template
            //create the item
            using (new SecurityDisabler())
            {
                var createdItem = contextItemFromMaster.Add(commentsForm.UserName, 
                                SitecoreTemplateConstants.CommentsFormTemplate);
                createdItem.Editing.BeginEdit();
                createdItem.Fields["UserName"].Value = commentsForm.UserName;
                createdItem.Fields["Gender"].Value = commentsForm.Gender;
                createdItem.Fields["Comment"].Value = commentsForm.Comment;
                createdItem.Editing.EndEdit();
            }
            //publish the item
            //source (master)
            //destination (web)
            PublishOptions publishOptions = new PublishOptions
                                            (masterDb,
                                            webDb,
                                            PublishMode.Smart,
                                            contextItem.Language,
                                            DateTime.Now);
            publishOptions.Deep = true;
            Publisher publisher = new Publisher(publishOptions);
            publisher.Publish();

            return View("~/Views/Tata/Forms/SubmissionSuccess.cshtml");
        }
    }
}
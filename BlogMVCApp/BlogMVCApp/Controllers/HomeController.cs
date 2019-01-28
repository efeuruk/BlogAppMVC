using BlogMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext db = new BlogContext();
        // GET: Home
        public ActionResult Index()
        {
            var blogs = db.Blogs.Select(i=> new BlogModel()
            {
                Id = i.Id,
                Title = i.Title.Length>100?i.Title.Substring(0,100)+"...":i.Title,
                Description = i.Description,
                Date = i.Date,
                HomePage = i.HomePage,
                Approval = i.Approval,
                Image = i.Image

            }).Where(i => i.Approval == true && i.HomePage == true);

            return View(blogs.ToList());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMVCApp.Models;

namespace BlogMVCApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id, string KeyWord)
        {
            var blogs = db.Blogs.Where(i => i.Approval == true).Select(i => new BlogModel()
            {
                Id = i.Id,
                Title = i.Title.Length > 100 ? i.Title.Substring(0, 100) + "..." : i.Title,
                Description = i.Description,
                Date = i.Date,
                HomePage = i.HomePage,
                Approval = i.Approval,
                Image = i.Image,
                CategoryId = i.CategoryId

            }).AsQueryable();

            if (id != null)
            {
                blogs = blogs.Where(i => i.CategoryId == id);
            }

            // For SearchBar Querying
            if (string.IsNullOrEmpty("KeyWord")==false)
            {
                blogs = blogs.Where(i => i.Title.Contains(KeyWord) || i.Description.Contains(KeyWord));
            }

            return View(blogs.ToList());
        }

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category);
            return View(blogs.OrderByDescending(i=>i.Date).ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Formda hangi alanlar istensin olayı yandaki Includeun parametrelerinde
        public ActionResult Create([Bind(Include = "Title,Description,Image,Content,CategoryId")] Blog blog) 
        {
            if (ModelState.IsValid)
            {
                blog.Date = DateTime.Now;

                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Image,Content,Approval,HomePage,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                // I used that lines because of the date time confisuon
                var entity = db.Blogs.Find(blog.Id);
                if (entity != null)
                {
                    entity.Title = blog.Title;
                    entity.Description = blog.Description;
                    entity.Image = blog.Image;
                    entity.Content = blog.Content;
                    entity.Approval = blog.Approval;
                    entity.HomePage = blog.HomePage;
                    entity.CategoryId = blog.CategoryId;
                    db.SaveChanges();
                    // To show which enrty is updated
                    TempData["Blog"] = entity;
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

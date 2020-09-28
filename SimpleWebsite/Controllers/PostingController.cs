using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleWebsite.Models;
using System.Data.Entity.Validation;

namespace SimpleWebsite.Controllers
{
    public class PostingController : Controller
    {
        private NugrahaBlogEntities db = new NugrahaBlogEntities();

        // GET: Posting
        public ActionResult Index()
        {
            return RedirectToAction("DisplayPost", "Posting");
            //return View(db.u_post.ToList());
        }

        public ActionResult ListIndex()
        {
            return View(db.u_post.ToList());
        }

        // GET: Posting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_post u_post = db.u_post.Find(id);
            if (u_post == null)
            {
                return HttpNotFound();
            }
            return View(u_post);
        }

        // GET: Posting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Post,Title,Id_Author,CreateTime,UpdateTime,Tags,Content")] u_post u_post)
        {
            if (ModelState.IsValid)
            {
                int last_id = db.u_post.Max(item => item.Id_Post);
                u_post.Id_Post = last_id + 1;
                u_post.CreateTime = DateTime.Now;
                u_post.UpdateTime = DateTime.Now;
                db.u_post.Add(u_post);                
                db.SaveChanges();
                return RedirectToAction("Index");                
            }

            return View(u_post);
        }

        // GET: Posting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_post u_post = db.u_post.Find(id);
            if (u_post == null)
            {
                return HttpNotFound();
            }
            return View(u_post);
        }

        // POST: Posting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id_Post,Title,Id_Author,CreateTime,UpdateTime,Tags,Content")] u_post u_post)
        {
            if (ModelState.IsValid)
            {
                
                u_post.UpdateTime = DateTime.Now;
                db.Entry(u_post).State = EntityState.Modified;    
                          
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                
                return RedirectToAction("Index");
            }
            return View(u_post);
        }

        // GET: Posting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_post u_post = db.u_post.Find(id);
            if (u_post == null)
            {
                return HttpNotFound();
            }
            return View(u_post);
        }

        // POST: Posting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            u_post u_post = db.u_post.Find(id);
            db.u_post.Remove(u_post);
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

        public ActionResult DisplayPost()
        {
            List<PostViewModel> datalist = db.u_post.Select(x => new PostViewModel
            {
                idPost = x.Id_Post,
                Title = x.Title,
                Content = x.Content,
                CreateDate = x.CreateTime
            }).ToList();
            return View(datalist);
        }
    }
}

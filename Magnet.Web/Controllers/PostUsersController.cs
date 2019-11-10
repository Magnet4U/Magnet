using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using Service;

namespace Magnet.Web.Controllers
{
    public class PostUsersController : Controller
    {
        public PostUserService postService { get; set; }
      //  public CommentService commentService { get; set; }

        public PostUsersController()
        {
            postService = new PostUserService();
           /// commentService = new CommentService();
        }
        // GET: Post
        public ActionResult Index()
        {

            return View(postService.GetMany());
        }
      
        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostUser post = postService.GetById((int)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostUser p, HttpPostedFileBase file)
        {
            {
                

                p.date_publication = DateTime.Now;
                p.Picture = file.FileName;
                
                postService.Add(p);
                postService.Commit();
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }
                return RedirectToAction("Index");
            }
        }
        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View(postService.GetById(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostUser p, HttpPostedFileBase file)
        {
            PostUser pn;
            pn = postService.GetById(id);
            pn.comments = p.comments;
            pn.contenu = p.contenu;
            pn.Picture = file.FileName;
            var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                file.SaveAs(path);
            }
            postService.Update(pn);
            postService.Commit();

            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            PostUser p;
            p = postService.GetById(id);
            postService.Delete(p);
            postService.Commit();
            return RedirectToAction("Index");
        }

    }
}

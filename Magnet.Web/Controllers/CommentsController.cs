using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magnet.Web.Controllers
{
    public class CommentController : Controller
    {
        CommentsService Cs;

        public CommentController()
        {
            Cs = new CommentsService();
        }
        // GET: Claim
        public ActionResult Indexx()
        {
            return View(Cs.GetMany());
        }
        // GET: Claim/Create
        public ActionResult Create()
        {
            var comments = Cs.GetMany();
            ViewBag.CategoryId = new SelectList(comments, "idComment");
            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(Comment q)

        {
            Comment p = new Comment();
            
            p.contenuComment = q.contenuComment;
            p.date_publication = DateTime.Now;


            Cs.Add(p);
            Cs.Commit();
            return RedirectToAction("Indexx");
        }
        public ActionResult Edit(int id)
        {
            return View(Cs.GetById(id));
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Comment p)
        {
            Comment pn;
            pn = Cs.GetById(id);
            pn.idComment = p.idComment;
            pn.contenuComment = p.contenuComment;


            Cs.Update(pn);
            Cs.Commit();

            return RedirectToAction("Indexx");

        }
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Comment p;
            p = Cs.GetById(id);
            Cs.Delete(p);
            Cs.Commit();
            return RedirectToAction("Indexx");
        }
        /*public ActionResult Index(string filtre)
        {
            var list = Cs.GetMany();


            // recherche
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.contenuComment.ToString().Equals(filtre)).ToList();
            }

            return View(list);



        }*/

    }
}

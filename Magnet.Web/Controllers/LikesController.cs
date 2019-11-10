using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using Service;

namespace Magnet.Web.Controllers
{
    public class LikesController : Controller
    {
        LikeService Cs;

        public LikesController()
        {
            Cs = new LikeService();
        }
        // GET: Claim
        public ActionResult Index()
        {
            return View(Cs.GetMany());
        }
        // GET: Claim/Create
        public ActionResult Create()
        {
            var likes = Cs.GetMany();
            ViewBag.CategoryId = new SelectList(likes, "idlike");
            return View();
        }
        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(Like q)

        {

            q.likes = 1;
            q.Dislikes = 0;


            Cs.Add(q);
            Cs.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult disCreate(Like q)

        {

            q.likes = 0;
            q.Dislikes = 1;


            Cs.Add(q);
            Cs.Commit();
            return RedirectToAction("Index");
        }

        // POST: Claim/Create

        public ActionResult Edit(int id)
        {
            return View(Cs.GetById(id));
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Like p)
        {
            Like pn;
            pn = Cs.GetById(id);
            pn.likes = 0;
            


            Cs.Update(pn);
            Cs.Commit();

            return RedirectToAction("Index");

        }
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
           Like p;
            p = Cs.GetById(id);
            Cs.Delete(p);
            Cs.Commit();
            return RedirectToAction("Index");
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

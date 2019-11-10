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
    public class MessagesController : Controller
    {
      //  private MyDBContext db = new MyDBContext();
        MessageService Cs;
        UserService CS;

        public MessagesController()
        {
            Cs = new MessageService();
            CS = new UserService();
        }
        // GET: Claim
        public ActionResult Index()
        {
            return View(Cs.GetMany());
        }
        // GET: Claim/Create
        public ActionResult Create()
        {
            //UserService us = new UserService();
            //IEnumerable<User> users = us.GetAll();
            //ViewBag.u = users;
            //var Messages = Cs.GetMany();
            //ViewBag.CategoryId = new SelectList(Messages, "idMessage");

            //return View();
            var categories = CS.GetMany();
            ViewBag.idUser = new SelectList(categories, "idUser", "cin");
            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(Message q)
        {
            bool Status = false;
            string message = "";
            //Model
            if (ModelState.IsValid)
            {
                Message p = q;

            Cs.Add(p);
            Cs.Commit();
             //   message = " Request";
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

          //  return View(q);
            return RedirectToAction("Create");
        }
        /* public ActionResult Create()
        {
            ViewBag.Users = db.DBSetEntreprise;

            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMessage,subject,body")] Message message)
        {
            if (ModelState.IsValid)
            {
                Cs.Add(message);
                Cs.Commit();
                return RedirectToAction("Index");
            }

            return View(message);
        }*/
        public ActionResult Edit(int id)
        {
            return View(Cs.GetById(id));
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Message p)
        {
            Message pn;
            pn = Cs.GetById(id);
            pn.idMessage = p.idMessage;
            pn.subject = p.subject;
            pn.body = p.body;

            Cs.Update(pn);
            Cs.Commit();

            return RedirectToAction("Index");

        }
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Message p;
            p = Cs.GetById(id);
            Cs.Delete(p);
            Cs.Commit();
            return RedirectToAction("Index");
        }

    }
}

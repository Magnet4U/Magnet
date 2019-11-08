using Data;
using Domain.Entities;
using Service;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Magnet.Web.Controllers
{
    public class QuizController : Controller
    {
        private MyDBContext db = new MyDBContext();
        IQuizService quizService = new QuizService();

        // GET: Quiz
        public ActionResult Index()
        {
            return View(db.DBSetQuiz.ToList());
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.DBSetQuiz.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }

            //count questions
            ViewBag.countquestions = null;
            if (TempData["countquestions"] != null)
            {
                ViewBag.countquestions = (int)TempData["countquestions"];
            }




            return View(quiz);
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: Quiz/Create
        [HttpPost]
        public ActionResult Create(string Public, [Bind(Include = "libelleQuiz")] Quiz newQuiz)
        {
            try
            {
                // TODO: Add insert logic here
                //newQuiz.idCandidat.username = System.Web.HttpContext.Current.User.Identity.Name;
                //newQuiz.DateModified = DateTime.Now.ToString();
            
                db.DBSetQuiz.Add(newQuiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateAdvanced()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdvanced(string Public, [Bind(Include = "libelleQuiz")] Quiz newQuiz)
        {

            
            //newTest.Owner = System.Web.HttpContext.Current.User.Identity.Name;
            //newTest.DateModified = DateTime.Now.ToString();
            //newTest.Status = Public;
            //newQuiz.IsAdvanced = true;



            db.DBSetQuiz.Add(newQuiz);
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
        public ActionResult AddNewQuestion(int? id)
        {
            ViewBag.ID = id;
            return View();
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.DBSetQuiz.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Public, [Bind(Include = "libelleQuiz")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                //quiz.Status = Public;
                //quiz.DateModified = DateTime.Now.ToString();
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PersonalProfile");
            }
            return View(quiz);
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.DBSetQuiz.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            Quiz quiz = db.DBSetQuiz.Find(id);
            db.DBSetQuiz.Remove(quiz);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public ActionResult AllTests()
        {
            return View(db.DBSetQuiz.ToList());
        }
    }
}

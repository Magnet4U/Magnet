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
//using Magnet.Web.Models;

namespace Magnet.Web.Controllers
{
    public class InterviewController : Controller
    {
        private MyDBContext db = new MyDBContext();
        IInterviewService intService = new InterviewService();

        // GET: Interview
        public ActionResult Index()
        {


            return View(intService.GetAll().ToList());
        }


        // GET: Interview/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IInterviewService intService = new InterviewService();
            Interview interview = intService.GetById(id);

            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);

        }

        // GET: Interview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interview/Create
        [HttpPost]
        public ActionResult Create(Interview interview)
        {

            try
            {
                // TODO: Add insert logic here
                //Ajouter un interview à partir de la classe InterviewService 


                IInterviewService intService = new InterviewService();
                intService.Add(interview);
                intService.Commit();
                //intService.Dispose();
                return RedirectToAction("Index");



            }
            catch
            {
                return View(interview);
            }
        }


        // GET: Interview/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IInterviewService intService = new InterviewService();
            Interview interview = intService.GetById(id);
            //intService.Update(interview);
            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);
        }

        // POST: Interview/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idInterview,DateInterview,lieu,Candidat_idUser")] Interview interview, int id)
        {
            if (ModelState.IsValid)
            {
                IInterviewService intService = new InterviewService();
                interview = intService.GetById(id);
                intService.Update(interview);
                //intService.Commit();
                //intService.Dispose();
                return RedirectToAction("Index");
            }
            return View(interview);

            //IInterviewService intService = new InterviewService();
            //interview = intService.GetById(id);
            //intService.Update(interview);
            //intService.Commit();
            ////intService.Dispose();
            //return RedirectToAction("Index");

            //return View(interview);
        }



        // GET: Interview/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IInterviewService intService = new InterviewService();
            Interview interview = intService.GetById(id);
            //Bloc bloc = db.Blocs.Find(id);
            if (interview == null)
            {
                return HttpNotFound();
            }
            return View(interview);
        }

        // POST: Interview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IInterviewService intService = new InterviewService();
            Interview interview = intService.GetById(id);
            intService.Delete(interview);
            intService.Commit();
            return RedirectToAction("Index");
        }


    }
}

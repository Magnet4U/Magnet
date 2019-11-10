using Data;
using Domain.Entities;
using Magnet.Web.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Magnet.Web.Controllers
{
    public class QuestionController : Controller
    {
        private MyDBContext db = new MyDBContext();
        IQuestionService questionService = new QuestionService();



        // GET: Question
        public ActionResult Index()
        {
            return View(questionService.GetAll().ToList());


        }


        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<Question> questionList = new List<Question>();
            if (SearchBy == "ID")
            {
                try
                {
                    int Id = Convert.ToInt32(SearchValue);
                    questionList = db.DBSetQuestion.Where(x => x.idQuestion == Id || SearchValue == null).ToList();

                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not An Id", SearchValue);

                }
                return Json(questionList, JsonRequestBehavior.AllowGet);

            }
            else
            {
                questionList = db.DBSetQuestion.Where(x => x.description.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(questionList, JsonRequestBehavior.AllowGet);


            }

        }

        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = questionService.GetById((long)id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "idQuestion,description,rep1,rep2,rep3,correctAnswer")] Question question)
        {
            if (ModelState.IsValid)
            {

                questionService.Add(question);
                questionService.Commit();

                return RedirectToAction("Index");
            }

            return View(question);
        }
        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = questionService.GetById((long)id);

            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idQuestion,description,rep1,rep2,rep3,correctAnswer,GroupingId")] Question question)
        {
            if (ModelState.IsValid)
            {
                questionService.Update(question);

                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = questionService.GetById((long)id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Question question = questionService.GetById(id);
            questionService.Delete(question);
            questionService.Commit();
            return RedirectToAction("Index");


        }

        public ActionResult AddNewQuestionAction(string id, string description, string optionb, string optionc, string optiond, string correctAnswer)
        {
            Question newQuestion = new Question();

            int newID = 0;
            Int32.TryParse(id, out newID);

            newQuestion.GroupingId = newID;
            newQuestion.description = description; //+ " :  ID = " + newID;
            newQuestion.correctAnswer = correctAnswer;
            newQuestion.rep1 = optionb;
            newQuestion.rep2 = optionc;
            newQuestion.rep3 = optiond;
            questionService.Add(newQuestion);
            questionService.Commit();
            //db.DBSetQuestion.Add(newQuestion);
            //db.SaveChanges();

            //pass id to add another question view
            TempData["id"] = id;

            return RedirectToAction("AddAnotherQuestion");
        }

        public ActionResult AddAnotherQuestion()
        {

            ViewBag.id = (string)TempData["id"];

            return View();
        }

        public ActionResult ViewQuestions(int? searchid)
        {

            var questions = from m in questionService.GetAll().ToList()
                            select m;
            if (searchid != null)
            {
                questions = questions.Where(s => s.GroupingId == searchid);
            }

            //new stuff here

            var tempQuestionlist = new List<Question>();
            tempQuestionlist = questions.ToList<Question>();
            //Globals.GlobalQuestionList = tempQuestionlist;

            //ViewBag.globals = Globals.GlobalQuestionList;

            return View(questions);

        }

        public ActionResult ViewGlobals()
        {

            ViewBag.count = Globals.GlobalQuestionList.Count();

            return View(Globals.GlobalQuestionList);
        }

        public ActionResult CustomTestPreFormatting(int? searchid)
        {


            var questions = from m in questionService.GetAll().ToList()
                            select m;
            if (searchid != null)
            {
                questions = questions.Where(s => s.GroupingId == searchid);
            }

            var tempQuestionlist = new List<Question>();
            tempQuestionlist = questions.ToList<Question>();

            TempData["tempQuestionlist"] = tempQuestionlist;

            //create a tempdata list to show answers in the final results page
            var reviewlist = new List<Question>();
            TempData["reviewlist"] = reviewlist;
            //create a tempdata list to track correct or incorrect answers.
            var CorrectorIncorrect = new List<string>();
            TempData["CorrectorIncorrect"] = CorrectorIncorrect;

            //debugging on this methods view
            ViewBag.globals = Globals.GlobalQuestionList;
            ViewBag.count = Globals.GlobalQuestionList.Count();

            //attempt to swith question authetication over to temp data
            double questionscorrect = 0;
            double questionswrong = 0;
            int questioncount = 1;
            TempData["questionscorrect"] = questionscorrect;
            TempData["questionswrong"] = questionswrong;
            TempData["questioncount"] = questioncount;


            return RedirectToAction("CustomTest", "ManageQuiz");

        }

        public ActionResult CountQuestionsInTest(int? id)
        {
            var questions = from m in questionService.GetAll().ToList()
                            select m;
            if (id != null)
            {
                questions = questions.Where(s => s.GroupingId == id);
            }

            int countquestions = questions.Count<Question>();
            TempData["countquestions"] = countquestions;

            return RedirectToAction("Details/" + id, "Quiz");
        }

        private static Random randomroll = new Random();
        private static Random random = new Random();
        //prints 10 questions with randmozed elements to a page.
        public ActionResult TestPDF(int? id, string title)
        {
            var questions = from m in questionService.GetAll().ToList()
                            select m;
            if (id != null)
            {
                questions = questions.Where(s => s.GroupingId == id);
            }

            //list to contain all filtered questions.
            var tempQuestionlist = new List<Question>();
            tempQuestionlist = questions.ToList<Question>();
            //list containing 10 fully scrambled questions.
            var UpdatedtempQuestionlist = new List<Question>();
            int count = tempQuestionlist.Count();
            //scramble questions and add them to updated list 10 times (10 questions total).
            for (int m = 0; m < 10; m++)
            {
                //create new instance of objects
                Question randomquestion = new Question();
                Question tempquestion = new Question();

                //choose a random question from questionlist
                int randomizeanswers;
                int choose = random.Next(0, count);
                randomquestion = tempQuestionlist[choose];


                List<string> scrambledanswers = new List<string>();
                scrambledanswers.Add(randomquestion.correctAnswer);
                scrambledanswers.Add(randomquestion.rep1);
                scrambledanswers.Add(randomquestion.rep2);
                scrambledanswers.Add(randomquestion.rep3);

                //assignanswervalues scrambled to tempquestion from random question.
                tempquestion.description = randomquestion.description;
                //for pdf version there is no answer authentication. Position does not correspond to
                //correctness
                //positionA
                randomizeanswers = randomroll.Next(0, 3);
                tempquestion.correctAnswer = scrambledanswers[randomizeanswers];
                scrambledanswers.RemoveAt(randomizeanswers);
                //positionB
                randomizeanswers = randomroll.Next(0, 2);
                tempquestion.rep1 = scrambledanswers[randomizeanswers];
                scrambledanswers.RemoveAt(randomizeanswers);
                //positionC
                randomizeanswers = randomroll.Next(0, 1);
                tempquestion.rep2 = scrambledanswers[randomizeanswers];
                scrambledanswers.RemoveAt(randomizeanswers);
                //positionD
                tempquestion.rep3 = scrambledanswers[0];

                //add modified question to list
                UpdatedtempQuestionlist.Add(tempquestion);
                //repeat 10 times
            }

            TempData["UpdatedtempQuestionlist"] = UpdatedtempQuestionlist;
            TempData["title"] = title;
            //return modifed list
            return RedirectToAction("ShowPDF", "ManageQuiz");
        }
    }
}

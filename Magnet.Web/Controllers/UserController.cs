using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Magnet.Web.Controllers
{
    public class UserController : Controller
    {
        MyDBContext db = new MyDBContext();

        //Register Action
        [HttpGet]
        public ActionResult Registration()
        {
           
                ViewBag.Entreprises = db.DBSetEntreprise;
           
            return View();
        }

        //Register Post Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified ,ActivationCode")] User user)
        {
            bool Status = false;
            string message = "";
            //Model
            if (ModelState.IsValid)
            {
                #region //Email mawjoud
                var isExist = IsEmailExist(user.email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email");
                    return View(user);
                }
                #endregion
                #region  Generate Activation Code
                user.ActivationCode = Guid.NewGuid();
                #endregion
                #region Password Hashng 
                user.password = Crypto.Hash(user.password);
                user.ConfirmPassword= Crypto.Hash(user.ConfirmPassword);
                #endregion 
                user.IsEmailVerified = false;
                #region  // Save in database
                using (MyDBContext db = new MyDBContext())
                {
                    db.DBSetUser.Add(user);
                    db.SaveChanges();

                    // Send email to user
                    SendVerificationLinkEmail(user.email, user.ActivationCode.ToString());
                    message = "Registration successfuly done . Account activation link" +
                        "has been sent to your email id : " + user.email;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(user);

        }
        // Verify Account
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (MyDBContext db = new MyDBContext())
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var v = db.DBSetUser.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    db.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }



        // Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Login Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl)
        {
            string message = "";
            using (MyDBContext db = new MyDBContext())
            {
                var v = db.DBSetUser.Where(a => a.email == login.EmailID).FirstOrDefault();
                if (v != null)
                {

                    if (string.Compare(Crypto.Hash(login.Password), v.password) == 0)
                    {
                        int timeout = login.RemeberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RemeberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            Console.Write(ReturnUrl);
                            return Redirect(ReturnUrl);

                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invaid Password provided";
                    }
                }
                else
                {
                    message = "Please verify your email first";
                }
            }
            ViewBag.Message = message;
            return View();
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (MyDBContext db = new MyDBContext())
            {
                var v = db.DBSetUser.Where(a => a.email == emailID).FirstOrDefault();
                return v != null;
            }
        }
        [NonAction]
        public void SendVerificationLinkEmail(String emailID, string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("alaeddine.chaibi@esprit.tn", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "espritinformatique";
            string subject = "Your account was succesfully created";

            string body = "<br/><br/> Your account is " +
                "Successfully created . Please click on the below link to verify your account" +
                "<br/><br/><a href='" + link + "'>" + link + "</a>";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

    }
}
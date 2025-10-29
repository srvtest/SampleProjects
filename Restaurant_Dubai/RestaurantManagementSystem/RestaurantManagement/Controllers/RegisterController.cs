//using System;
//using System.Globalization;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;
//using RestaurantManagement.Models;
//using EntityLayer;
//using DataLayer;
//using System.Data;

//namespace RestaurantManagement.Controllers
//{
//    public class RegisterController : Controller
//    {
        
//        public ActionResult Index()
//        {
            
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public ActionResult Register(RegisterModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Attempt to register the user
//                try
//                {
//                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { EmailId = model.EmailId, Details = model.Details });

//                    WebSecurity.Login(model.UserName, model.Password);
//                    return RedirectToAction("Index", "Home");
//                }
//                catch (MembershipCreateUserException e)
//                {
//                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
//                }
//            }

//            // If we got this far, something failed, redisplay form
//            return View(model);
//        }

//        [AllowAnonymous]
//        public ActionResult ForgotPassword()
//        {
//            return View();
//        }




//[HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public ActionResult ForgotPassword(string UserName)
//        {
//            //check user existance
//            var user = Membership.GetUser(UserName);
//            if (user == null)
//            {
//                TempData["Message"] = "User Not exist.";
//            }
//            else
//            {
//                //generate password token
//                var token = WebSecurity.GeneratePasswordResetToken(UserName);
//                //create url with above token
//                var resetLink = "<a href='" + Url.Action("ResetPassword", "Account", new { un = UserName, rt = token }, "http") + "'>Reset Password</a>";
//                //get user emailid
//                UsersContext db = new UsersContext();
//                var emailid = (from i in db.UserProfiles
//                               where i.UserName == UserName
//                               select i.EmailId).FirstOrDefault();
//                //send mail
//                string subject = "Password Reset Token";
//                string body = "<b>Please find the Password Reset Token</b><br/>" + resetLink; //edit it
//                try
//                {
//                    SendEMail(emailid, subject, body);
//                    TempData["Message"] = "Mail Sent.";
//                }
//                catch (Exception ex)
//                {
//                    TempData["Message"] = "Error occured while sending email." + ex.Message;
//                }
//                //only for testing
//                TempData["Message"] = resetLink;
//            }

//            return View();
//        }

//        [AllowAnonymous]
//        public ActionResult ResetPassword(string un, string rt)
//        {
//            UsersContext db = new UsersContext();
//            //TODO: Check the un and rt matching and then perform following
//            //get userid of received username
//            var userid = (from i in db.UserProfiles
//                          where i.UserName == un
//                          select i.UserId).FirstOrDefault();
//            //check userid and token matches
//            bool any = (from j in db.webpages_Memberships
//                        where (j.UserId == userid)
//                        && (j.PasswordVerificationToken == rt)
//                        //&& (j.PasswordVerificationTokenExpirationDate < DateTime.Now)
//                        select j).Any();

//            if (any == true)
//            {
//                //generate random password
//                string newpassword = GenerateRandomPassword(6);
//                //reset password
//                bool response = WebSecurity.ResetPassword(rt, newpassword);
//                if (response == true)
//                {
//                    //get user emailid to send password
//                    var emailid = (from i in db.UserProfiles
//                                   where i.UserName == un
//                                   select i.EmailId).FirstOrDefault();
//                    //send email
//                    string subject = "New Password";
//                    string body = "<b>Please find the New Password</b><br/>" + newpassword; //edit it
//                    try
//                    {
//                        SendEMail(emailid, subject, body);
//                        TempData["Message"] = "Mail Sent.";
//                    }
//                    catch (Exception ex)
//                    {
//                        TempData["Message"] = "Error occured while sending email." + ex.Message;
//                    }

//                    //display message
//                    TempData["Message"] = "Success! Check email we sent. Your New Password Is " + newpassword;
//                }
//                else
//                {
//                    TempData["Message"] = "Hey, avoid random request on this page.";
//                }
//            }
//            else
//            {
//                TempData["Message"] = "Username and token not maching.";
//            }

//            return View();
//        }



//    }
//}
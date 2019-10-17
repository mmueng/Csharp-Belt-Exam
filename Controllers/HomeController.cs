using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Belt_Exam.Models;

namespace Belt_Exam.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewModel viewM = new ViewModel();
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(User NewUser)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.User.Any(u => u.Email == NewUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already Exist!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                dbContext.User.Add(NewUser);
                dbContext.SaveChanges();

                HttpContext.Session.SetInt32("id", NewUser.UserId);
                int? logUser = HttpContext.Session.GetInt32("id");
                ViewBag.logUser = logUser;

                return RedirectToAction("Privacy");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("LoginProcess")]
        public IActionResult LoginProcess(ViewModel userSubmission)
        {
            // if (ModelState.IsValid)
            // {
            // If inital ModelState is valid, query for a user with provided email
            // var userInDb = dbContext.User.FirstOrDefault(u => u.Email == userSubmission.LoginUser.Email);
            // // If no user exists with provided email
            // if (userInDb == null)
            // {
            //     // Add an error to ModelState and return to View!
            //     ModelState.AddModelError("Email", "Invalid Email/Password");
            //     return View("Index");
            // }
            // // Initialize hasher object
            // var hasher = new PasswordHasher<LoginUser>();
            // // verify provided password against hash stored in db
            // var result = hasher.VerifyHashedPassword(userSubmission.LoginUser, userInDb.Password, userSubmission.LoginUser.Password);
            // System.Console.WriteLine("*********" + result);
            // // result can be compared to 0 for failure

            // if (hasher.VerifyHashedPassword(userSubmission.LoginUser, userInDb.Password, userSubmission.LoginUser.Password) == PasswordVerificationResult.Failed)
            if (ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.User.FirstOrDefault(u => u.Email == userSubmission.LoginUser.Email);
                // If no user exists with provided email
                if (userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                // Initialize hasher object
                if (userSubmission.LoginUser.Password == null)
                {
                    ModelState.AddModelError("Email", "Invalid email/password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                // verify provided password against hash stored in db
                // var result = hasher.VerifyHashedPassword (userSubmission, userInDb.Password, userSubmission.Password);
                // System.Console.WriteLine ("*********" + result);
                // result can be compared to 0 for failure
                if (hasher.VerifyHashedPassword(userSubmission.LoginUser, userInDb.Password, userSubmission.LoginUser.Password) == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("Email", "Invalid email/password");
                    return View("Index");
                }
                else
                {
                    HttpContext.Session.SetInt32("id", userInDb.UserId);
                    int? logUser = HttpContext.Session.GetInt32("id");

                    ViewBag.logUser = logUser;

                    List<Activitys> Allw = dbContext.Activitys.Include(p => p.User).Include(a => a.Assoc_Activity).ToList();

                    System.Console.WriteLine("********** " + Allw + " *******");
                    foreach (var a in Allw)
                    {
                        DateTime dateTime12 = Convert.ToDateTime(a.Date);
                        if (dateTime12 < DateTime.Now)
                        {
                            Activitys deleteW = dbContext.Activitys.FirstOrDefault(w => w.ActivityId == a.ActivityId);
                            System.Console.WriteLine("*************************" + deleteW.UserId);
                            dbContext.Remove(deleteW);
                            dbContext.SaveChanges();
                        }
                    }
                    return RedirectToAction("Privacy");
                }

            }
            else { return View("Index"); }
        }






        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            int? logUser = HttpContext.Session.GetInt32("id");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("Success")]
        public IActionResult Privacy()
        {
            int? logUser = HttpContext.Session.GetInt32("id");
            if (logUser == null)
            {
                return View("Index");
            }
            ViewBag.logUser = logUser;
            User loguser = dbContext.User.SingleOrDefault(User => User.UserId == logUser);
            ViewBag.loguserr = loguser;
            // ViewBag.logUser = logUser;
            ViewModel viewmodel = new ViewModel();
            viewmodel.NewUser = loguser;

            // List<Wedding> AllWedding = dbContext.Wedding.ToList ();
            // viewmodel.AllWeddings = AllWedding;

            List<Activitys> Allw = dbContext.Activitys.Include(p => p.User).Include(a => a.Assoc_Activity).ToList();
            // viewmodel.AllActivity = Allw;

            List<Activitys> DojoActivities = dbContext.Activitys.Include(x => x.User).Include(y => y.Assoc_Activity).ThenInclude(z => z.User).ToList();
            ViewBag.AllActiv = DojoActivities;

            foreach (var a in Allw)
            {
                System.Console.WriteLine("**************" + a.Date);
                // DateTime loadedDate = DateTime.ParseExact(a.Date, "d", null);
                // System.Console.WriteLine("**************" + loadedDate);

            }



            return View(Allw);
        }

        [HttpGet("Success/NewActivitys")]
        public IActionResult NewActivitys()
        {
            return View("NewActivity");
        }

        [HttpPost("Success/NewActivitys")]
        public IActionResult NewActivitys(Activitys submission)
        {
            System.Console.WriteLine("*********************" + submission.Date);
            DateTime dateTime12 = Convert.ToDateTime(submission.Date);
            if (dateTime12 < DateTime.Now)
            {
                return View("NewActivity");
            }
            if (ModelState.IsValid)
            {
                int? logUser = HttpContext.Session.GetInt32("id");

                submission.UserId = (int)logUser;
                dbContext.Add(submission);
                dbContext.SaveChanges();
                return RedirectToAction("Privacy");
            }
            else
            {
                return View("NewActivity");
            }
        }

        [HttpGet("AddUserToActivity/{aId}")]
        public IActionResult AddUserToActivity(int aId)
        {
            int? LoginUser = HttpContext.Session.GetInt32("id");
            System.Console.WriteLine("*********************************************************************");
            System.Console.WriteLine("***" + LoginUser + " ****** " + aId + "************************");
            User LogUser = dbContext.User.FirstOrDefault(User => User.UserId == LoginUser);
            ViewBag.loginUser = LogUser;
            Activitys thisWedding = dbContext.Activitys.FirstOrDefault(w => w.ActivityId == aId);
            Association NewGuest = new Association();
            NewGuest.UserId = LogUser.UserId;
            NewGuest.ActivityId = thisWedding.ActivityId;
            dbContext.association.Add(NewGuest);

            dbContext.SaveChanges();
            return RedirectToAction("Privacy");
        }

        [HttpGet("RemoveUserFromActivity/{aId}")]
        public IActionResult RemoveUserFromActivity(int aId)
        {
            int? LoginUser = HttpContext.Session.GetInt32("id");
            User LogUser = dbContext.User.FirstOrDefault(u => u.UserId == LoginUser); ViewBag.loginUser = LogUser;
            Activitys thisWedding = dbContext.Activitys.FirstOrDefault(w => w.ActivityId == aId);
            Association this_Wedding = dbContext.association.FirstOrDefault(u => u.ActivityId == aId && u.UserId == (int)LoginUser);
            dbContext.Remove(this_Wedding);
            dbContext.SaveChanges();
            return RedirectToAction("Privacy");
        }

        [HttpGet("show/{WId}")]
        public IActionResult Show(int WId)
        {
            int? logUser = HttpContext.Session.GetInt32("id");
            if (logUser == null)
            {
                return View("Index");
            }
            User loginUser = dbContext.User.FirstOrDefault(u => u.UserId == logUser);
            ViewBag.loginUser = logUser;
            // ViewModel viewmodel = new ViewModel ();
            // viewmodel.NewUser = loginUser;

            // Wedding CurrWedding = dbContext.Wedding.FirstOrDefault (w => w.WeddingId == WId);
            // viewmodel.NewWedding = CurrWedding;

            Activitys Allguests = dbContext.Activitys.Include(a => a.Assoc_Activity).ThenInclude(a => a.User).FirstOrDefault(w => w.ActivityId == WId);
            ViewBag.Allguests = Allguests;


            Activitys Activity = dbContext.Activitys.Include(x => x.User).Include(y => y.Assoc_Activity).ThenInclude(z => z.User).FirstOrDefault(act => act.ActivityId == WId);
            ViewBag.Activity = Activity;
            ViewBag.User = User;
            return View(Allguests);
        }

        [HttpPost("Join/{aId}")]
        public IActionResult Join(int aId)
        {
            System.Console.WriteLine("****************************join*****************************************");
            int? logUser = HttpContext.Session.GetInt32("id");
            if (logUser == null)
            {
                return View("Index");
            }
            ViewBag.logUser = logUser;
            Activitys Activity = dbContext.Activitys.Include(x => x.User).Include(y => y.Assoc_Activity).ThenInclude(z => z.User).FirstOrDefault(act => act.ActivityId == aId);
            ViewBag.Activity = Activity;
            // ViewBag.logUser = logUser;
            Activitys Join = dbContext.Activitys.FirstOrDefault(d => d.ActivityId == aId);
            User LogUser = dbContext.User.FirstOrDefault(User => User.UserId == logUser);
            Association NewGuest = new Association();
            System.Console.WriteLine("**********" + (int)logUser + "------" + aId + "******************1join*****************************************");
            NewGuest.UserId = (int)logUser;
            NewGuest.ActivityId = aId;
            System.Console.WriteLine("***************************2*join*****************************************");
            dbContext.Add(NewGuest);
            System.Console.WriteLine("***************************3*join*****************************************");
            dbContext.SaveChanges();
            return RedirectToAction("Privacy");
        }

        [HttpGet("{aId}")]
        public IActionResult RemoveUserFromActivitys(int aId)
        {
            int? LoginUser = HttpContext.Session.GetInt32("id");
            User LogUser = dbContext.User.FirstOrDefault(u => u.UserId == LoginUser);
            System.Console.WriteLine("***********************************");
            Association this_Wedding = dbContext.association.FirstOrDefault(u => u.ActivityId == aId && u.UserId == (int)LoginUser);
            System.Console.WriteLine("***********************************");
            dbContext.Remove(this_Wedding);
            dbContext.SaveChanges();
            System.Console.WriteLine("***********************************");
            return RedirectToAction("Privacy");
        }


        [HttpGet("Delete/{Wid}")]
        public IActionResult Delete(int WId)
        {
            int? logUser = HttpContext.Session.GetInt32("id");
            if (logUser == null)
            {
                return View("Index");
            }
            Activitys deleteW = dbContext.Activitys.FirstOrDefault(w => w.ActivityId == WId);
            System.Console.WriteLine("*************************" + deleteW.UserId);
            if (deleteW.UserId == logUser)
            {

                dbContext.Remove(deleteW);
                dbContext.SaveChanges();
            }
            else
            {
                return View("Privacy");
            }
            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
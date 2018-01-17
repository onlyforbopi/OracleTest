using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OracleTest10.Models;

namespace OracleTest10.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        // This will redirect us to main login view : Index
        // View will be stored into Views/Login/Index.cshtml
        // No parameter is passed.
        public ActionResult Index()
        {
            return View();
        }



        // Specify PostURL for LoginForm
        [HttpPost]
        public ActionResult Authorize(OracleTest10.Models.USR userModel)
        {
            // Here we handle login sumissions
            // The submission form values will be of the type class 
            //       OracleTest10.Models.USR
            //
            // This is the class defined by ADO in User.cs


            // We find class name for our db from DBNAME.Context.cs
            // The following command instantiates a db of that class
            using (OREntities db = new OREntities())
            {

                // If there's any user with that username/pass the userDetails will fill, success
                // Standard LINQ command: <db>.<tablename>.Where()
                // Performs a query for values AM = InputAM and PASSWORD = InputPASSWORD
                // FirstOrDefault returns the first entry, or default if they found none.
                var userDetails = db.USRs.Where(x => x.ID == userModel.ID && x.PASSWORD == userModel.PASSWORD).FirstOrDefault();
                
                // if its null
                if (userDetails == null)
                {
                    // We ve added a property in the User.cs file to handle error message.
                    // Property added in User.cs : 
                    userModel.LoginErrorMessage = "Wrong Credentials";
                    return View("Index", userModel);
                }
                else
                {
                    // If login is succesfull, we set several parameters
                    // as session parameters (they will last throughout the session)
                    // This is used in conjuction with a razor block at the beginning
                    // of every other view (but for login), where we will check if
                    // Session["userID"] is null, and if so, we ll redirect to the main page.
                    Session["userID"] = userDetails.ID;
                    Session["Name"] = userDetails.FIRST_NAME;
                    Session["Surname"] = userDetails.LAST_NAME;

                    // Here, we redirect to our main page, controller: Other, action: Index
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("Index", "Other");
                }
                //return View();
            }

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}

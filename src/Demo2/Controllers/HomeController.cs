using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Demo2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // TODO: 4. Now we can grab that token at any time to do with it as we please, because at this point the token is in the database in the AspNetUserClaims table
            ViewBag.Message = "We cannot find a Salesforce token yet. Perhaps you should try signing in?";

            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "urn:tokens:salesforce:accesstoken");
                if (claim != null)
                    ViewBag.Message = string.Format("Your Salesforce access token is: {0}", claim.Value);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Demo2.Models;
using Salesforce.Common;
using Salesforce.Common.Models;
using Salesforce.Force;

namespace Demo2.Controllers
{
    public class ContactsController : Controller
    {
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var accessToken = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "urn:tokens:salesforce:accesstoken").Value.ToString();
            var instanceUrl = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "urn:tokens:salesforce:instance_url").Value.ToString();

            var client = new ForceClient(instanceUrl, accessToken, "v32.0");
            var contacts = await client.QueryAsync<Contact>("SELECT Id, FirstName, LastName From Contact");

            return View(contacts.records);
        }

    }
}
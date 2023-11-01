using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Web_Autentifie_NetPasseport.Models;
using System.Diagnostics;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace MVC_Web_Autentifie_NetPasseport.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GraphServiceClient graphServiceClient)
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;;
        }

 //       [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
        public  IActionResult Index()
        {
            var user = _graphServiceClient.Identity?.ToGetRequestInformation();
            ViewData["GraphApiResult"] = user;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
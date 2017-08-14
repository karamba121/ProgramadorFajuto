using Microsoft.AspNetCore.Mvc;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

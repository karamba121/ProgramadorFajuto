using Microsoft.AspNetCore.Mvc;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

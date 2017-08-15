using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProgramadorFajuto.Web.Portal.Extensions;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.AdicionarMensagemDeErro("olha so pra isso.");
            return this.View();
        }
    }
}

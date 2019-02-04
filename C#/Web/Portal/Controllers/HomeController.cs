using Microsoft.AspNetCore.Mvc;
using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;
using ProgramadorFajuto.Application.Aplicacao.Portal.Modelos;
using ProgramadorFajuto.Application.Aplicacao.Util.Modelos.Base;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Web.Portal.Filters;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    public class HomeController : Controller
    {
        private IServicoDeHome _servicoDeHome;

        public HomeController(IServicoDeHome servicoDeHome) => this._servicoDeHome = servicoDeHome;

        [HttpGet]
        [ExcecoesFilter]
        public IActionResult Index(int? pagina)
        {
            var posts = this._servicoDeHome.ListarPosts();
            var postsMaisPopulares = this._servicoDeHome.ListarPostsMaisPopulares(posts);

            return View(new ModeloDeHome(ModeloDeLista<Post>.Criar(posts, pagina ?? 1), postsMaisPopulares));
        }
    }
}

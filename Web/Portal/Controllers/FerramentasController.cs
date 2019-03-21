using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    public class FerramentasController : Controller
    {
        private readonly IServicoDeFerramentas _servicoDeFerramentas;

        public FerramentasController(IServicoDeFerramentas servicoDeFerramentas)
        {
            this._servicoDeFerramentas = servicoDeFerramentas;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult FormatarEmailMarketing()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult FormatarEmailMarketing(IFormFile arquivo)
        {
            return File(this._servicoDeFerramentas.Formatar(arquivo), "application/file", "EmailFormatado.html");
        }
    }
}

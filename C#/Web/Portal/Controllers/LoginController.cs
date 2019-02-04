using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;
using ProgramadorFajuto.Application.Aplicacao.Portal.Modelos;
using ProgramadorFajuto.Web.Portal.Extensions;
using ProgramadorFajuto.Web.Portal.Filters;
using System.Threading.Tasks;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServicoDeLogin _servicoDeLogin;

        public LoginController(IServicoDeLogin servicoDeLogin)
        {
            this._servicoDeLogin = servicoDeLogin;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return this.View();
        }

        [HttpPost]
        [ExcecoesFilter]
        public async Task<IActionResult> Autenticar(ModeloDeLogin modeloDeLogin, string returnUrl = null)
        {
            await this._servicoDeLogin.AutenticarAsync(modeloDeLogin);

            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        [ExcecoesFilter]
        public async Task<IActionResult> Deslogar()
        {
            await this._servicoDeLogin.DeslogarAsync();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [ExcecoesFilter]
        public async Task<IActionResult> Cadastrar(string nome, string email, string senha)
        {
            await this._servicoDeLogin.CadastrarAsync(nome, email, senha);

            this.AdicionarMensagemDeSucesso("Você se cadastrou com sucesso, Bem vindo!");

            return RedirectToAction("Index", "Home");
        }
    }
}

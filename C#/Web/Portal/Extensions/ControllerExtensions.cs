using Microsoft.AspNetCore.Mvc;

namespace ProgramadorFajuto.Web.Portal.Extensions
{
    public static class ControllerExtensions
    {
        public static void AdicionarMensagem(this Controller controllerBase, string mensagem) => controllerBase.TempData["Mensagem"] = mensagem;

        public static void AdicionarMensagemDeSucesso(this Controller controllerBase, string mensagem) => controllerBase.TempData["MensagemDeSucesso"] = mensagem;

        public static void AdicionarMensagemDeErro(this Controller controllerBase, string mensagem) => controllerBase.TempData["MensagemDeErro"] = mensagem;
    }
}

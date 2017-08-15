using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProgramadorFajuto.Application.Aplicacao.Util;
using ProgramadorFajuto.Web.Portal.Extensions;

namespace ProgramadorFajuto.Web.Portal.Filters
{
    public sealed class ExcecoesFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var controller = context.Controller as Controller;
                var excecao = context.Exception as ExcecaoDeAplicacao;

                context.ExceptionHandled = true;
                controller.AdicionarMensagemDeErro(excecao.Mensagem);
                context.Result = new RedirectResult(!string.IsNullOrEmpty(context.HttpContext.Request.Headers["Referer"].ToString()) ? context.HttpContext.Request.Headers["Referer"].ToString() : context.HttpContext.Request.Path.ToString());
            }
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ProgramadorFajuto.Application.Aplicacao.Util;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeAutenticacao
{
    public class AutenticacaoPorCookie : IServicoDeAutenticacao
    {
        private readonly VariaveisDeAmbiente _variaveisDeAmbiente;
        private readonly IHttpContextAccessor _contexto;

        public AutenticacaoPorCookie(IOptions<VariaveisDeAmbiente> variaveis, IHttpContextAccessor contexto)
        {
            this._variaveisDeAmbiente = variaveis.Value;
            this._contexto = contexto;
        }

        public async Task AutenticarAsync(IDictionary<string, object> parametros)
        {
            var identidade = new ClaimsIdentity(this.GerarClaims(parametros), CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identidade);

            await this._contexto.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            });
        }

        private Claim[] GerarClaims(IDictionary<string, object> parametros)
        {
            var claims = new List<Claim>();

            foreach (var parametro in parametros)
            {
                var valor = "";
                var chave = parametro.Key.ToLower();

                if (parametro.Value != null)
                    valor = parametro.Value.ToString();

                claims.Add(new Claim(chave, valor));
            }

            return claims.ToArray();
        }

        public async Task DeslogarAsync()
        {
            await this._contexto.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

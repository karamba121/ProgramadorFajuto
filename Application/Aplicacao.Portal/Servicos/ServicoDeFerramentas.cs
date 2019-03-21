using Microsoft.AspNetCore.Http;
using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;
using ProgramadorFajuto.Application.Aplicacao.Util;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System;
using System.IO;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Servicos
{
    public class ServicoDeFerramentas : IServicoDeFerramentas
    {
        private readonly IServicoDeFormatacaoDeEmail _servicoDeFormatacaoDeEmail;

        public ServicoDeFerramentas(IServicoDeFormatacaoDeEmail servicoDeFormatacaoDeEmail)
        {
            this._servicoDeFormatacaoDeEmail = servicoDeFormatacaoDeEmail;
        }

        public Stream Formatar(IFormFile arquivo)
        {
            try
            {
                return this._servicoDeFormatacaoDeEmail.Formatar(arquivo);
            }

            catch (ExcecaoDeAplicacao)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw new ExcecaoDeAplicacao(ex.Message);
            }
        }
    }
}

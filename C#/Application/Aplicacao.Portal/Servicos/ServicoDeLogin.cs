using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;
using ProgramadorFajuto.Application.Aplicacao.Portal.Modelos;
using ProgramadorFajuto.Application.Aplicacao.Util;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Servicos
{
    public class ServicoDeLogin : IServicoDeLogin
    {
        private readonly IServicoDePersistencia _servicoDePersistencia;
        private readonly IServicoDeCriptografia _servicoDeCriptografia;
        private readonly IServicoDeAutenticacao _servicoDeAutenticacao;

        public ServicoDeLogin(IServicoDePersistencia servicoDePersistencia, IServicoDeCriptografia servicoDeCriptografia, IServicoDeAutenticacao servicoDeAutenticacao)
        {
            this._servicoDePersistencia = servicoDePersistencia;
            this._servicoDeCriptografia = servicoDeCriptografia;
            this._servicoDeAutenticacao = servicoDeAutenticacao;
        }

        public async Task AutenticarAsync(ModeloDeLogin modeloDeLogin)
        {
            try
            {
                var usuario = this._servicoDePersistencia.RepositorioDeUsuarios.Obter(p => p.Email == modeloDeLogin.Email);

                if (usuario == null)
                    throw new ExcecaoDeAplicacao("Usuário não encontrado.");

                var senhaCriptografada = this._servicoDeCriptografia.ObterHash(modeloDeLogin.Senha + usuario.Salt);

                if (senhaCriptografada != usuario.SenhaCriptografada)
                    throw new ExcecaoDeAplicacao("Senha incorreta.");

                var parametros = new Dictionary<string, object>()
                {
                    {"Id", usuario.Id },
                    {"Nome", usuario.Nome }
                };

                await this._servicoDeAutenticacao.AutenticarAsync(parametros);
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

        public async Task CadastrarAsync(string nome, string email, string senha)
        {
            try
            {
                var sal = this._servicoDeCriptografia.ObterSalt();
                var senhaCriptografada = this._servicoDeCriptografia.ObterHash(senha + sal);

                var usuario = this._servicoDePersistencia.RepositorioDeUsuarios.Adicionar(new Usuario(nome, email, sal, senhaCriptografada));

                this._servicoDePersistencia.Persistir();

                var parametros = new Dictionary<string, object>()
                {
                    {"Id", usuario.Id },
                    {"Nome", usuario.Nome }
                };

                await this._servicoDeAutenticacao.AutenticarAsync(parametros);
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

        public async Task DeslogarAsync()
        {
            try
            {
                await this._servicoDeAutenticacao.DeslogarAsync();
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

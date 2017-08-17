using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;
using ProgramadorFajuto.Application.Aplicacao.Util;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System;
using System.Collections.Generic;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Servicos
{
    public class ServicoDePost : IServicoDePost
    {
        private readonly IServicoDePersistencia _servicoDePersistencia;

        public ServicoDePost(IServicoDePersistencia servicoDePersistencia) => this._servicoDePersistencia = servicoDePersistencia;

        public IEnumerable<Post> ListarPosts()
        {
            try
            {
                return this._servicoDePersistencia.RepositorioDePosts.ListarTodos();
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

        public IEnumerable<Tag> ListarTags()
        {
            try
            {
                return this._servicoDePersistencia.RepositorioDeTags.ListarTodos();
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

        public Post ObterPostPorId(int id)
        {
            try
            {
                return this._servicoDePersistencia.RepositorioDePosts.Obter(p => p.Id == id);
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

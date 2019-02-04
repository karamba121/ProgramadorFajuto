using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;
using ProgramadorFajuto.Application.Aplicacao.Util;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Servicos
{
    public class ServicoDeHome : IServicoDeHome
    {
        private readonly IServicoDePersistencia _servicoDePersistencia;

        public ServicoDeHome(IServicoDePersistencia servicoDePersistencia) => this._servicoDePersistencia = servicoDePersistencia;

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

        public IEnumerable<Post> ListarPosts(int pagina)
        {
            try
            {
                return this._servicoDePersistencia.RepositorioDePosts.ListarTodos(pagina);
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

        public IEnumerable<Post> ListarPostsMaisPopulares(IEnumerable<Post> posts)
        {
            try
            {
                return posts.OrderBy(p => p.Comentarios.Count()).Take(5).ToList();
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

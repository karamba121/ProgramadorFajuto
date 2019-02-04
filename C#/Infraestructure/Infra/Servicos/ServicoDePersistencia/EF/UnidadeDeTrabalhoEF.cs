using ProgramadorFajuto.Domain.Dominio.Repositorios;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Fabricas;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Repositorios;
using System;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF
{
    public class UnidadeDeTrabalhoEF : IServicoDePersistencia, IDisposable
    {
        private readonly ContextoEF _contexto;
        private readonly FabricaDeRepositorios _fabricaDeRepositorios;

        public UnidadeDeTrabalhoEF(ContextoEF contexto)
        {
            this._contexto = contexto;
            this._fabricaDeRepositorios = new FabricaDeRepositorios(contexto);
        }

        public IRepositorioDeUsuarios RepositorioDeUsuarios => this._fabricaDeRepositorios.PegarRepositorio<IRepositorioDeUsuarios, RepositorioDeUsuarios>();
        public IRepositorioDePosts RepositorioDePosts => this._fabricaDeRepositorios.PegarRepositorio<IRepositorioDePosts, RepositorioDePosts>();
        public IRepositorioDeBlogs RepositorioDeBlogs => this._fabricaDeRepositorios.PegarRepositorio<IRepositorioDeBlogs, RepositorioDeBlogs>();
        public IRepositorioDeComentarios RepositorioDeComentarios => this._fabricaDeRepositorios.PegarRepositorio<IRepositorioDeComentarios, RepositorioDeComentarios>();
        public IRepositorioDeTags RepositorioDeTags => this._fabricaDeRepositorios.PegarRepositorio<IRepositorioDeTags, RepositorioDeTags>();

        public void Dispose()
        {
            this._contexto.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Persistir() => this._contexto.SaveChanges();
    }
}

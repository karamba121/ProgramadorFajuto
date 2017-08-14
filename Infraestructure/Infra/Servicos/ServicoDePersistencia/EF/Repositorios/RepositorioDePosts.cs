using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Domain.Dominio.Repositorios;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Repositorios.Base;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Repositorios
{
    public class RepositorioDePosts : RepositorioEF<Post>, IRepositorioDePosts
    {
        public RepositorioDePosts(ContextoEF contexto) : base(contexto) { }
    }
}

using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Domain.Dominio.Repositorios;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Repositorios.Base;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Repositorios
{
    public class RepositorioDeTags : RepositorioEF<Tag>, IRepositorioDeTags
    {

        public RepositorioDeTags(ContextoEF contexto) : base(contexto) { }
    }
}

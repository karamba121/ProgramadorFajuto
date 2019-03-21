using ProgramadorFajuto.Domain.Dominio.Repositorios;

namespace ProgramadorFajuto.Infraestructure.Infra.Contratos
{
    public interface IServicoDePersistencia
    {
        void Persistir();

        IRepositorioDeUsuarios RepositorioDeUsuarios { get; }
        IRepositorioDePosts RepositorioDePosts { get; }
        IRepositorioDeBlogs RepositorioDeBlogs { get; }
        IRepositorioDeComentarios RepositorioDeComentarios { get; }
        IRepositorioDeTags RepositorioDeTags { get; }
    }
}

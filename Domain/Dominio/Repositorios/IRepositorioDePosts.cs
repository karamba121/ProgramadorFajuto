using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Domain.Dominio.Repositorios.Base;
using System.Collections.Generic;

namespace ProgramadorFajuto.Domain.Dominio.Repositorios
{
    public interface IRepositorioDePosts : IRepositorio<Post>
    {
        new IEnumerable<Post> ListarTodos();
        IEnumerable<Post> ListarTodos(int pagina);
    }
}

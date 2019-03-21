using ProgramadorFajuto.Domain.Dominio.Entidades;
using System.Collections.Generic;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Contratos
{
    public interface IServicoDeHome
    {
        IEnumerable<Post> ListarPosts();
        IEnumerable<Post> ListarPosts(int pagina);
        IEnumerable<Post> ListarPostsMaisPopulares(IEnumerable<Post> posts);
    }
}

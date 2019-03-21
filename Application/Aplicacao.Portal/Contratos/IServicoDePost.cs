using ProgramadorFajuto.Domain.Dominio.Entidades;
using System.Collections.Generic;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Contratos
{
    public interface IServicoDePost
    {
        Post ObterPostPorId(int id);
        IEnumerable<Post> ListarPosts();
        IEnumerable<Tag> ListarTags();
    }
}

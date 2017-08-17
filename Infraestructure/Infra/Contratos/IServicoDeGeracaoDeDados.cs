using ProgramadorFajuto.Domain.Dominio.Entidades;
using System.Collections.Generic;

namespace ProgramadorFajuto.Infraestructure.Infra.Contratos
{
    public interface IServicoDeGeracaoDeDados
    {
        IEnumerable<Usuario> GerarUsuarios(int quantidade);
        IEnumerable<Post> GerarPosts(int quantidade, IEnumerable<Tag> tags, IEnumerable<Usuario> usuarios);
        IEnumerable<Tag> GerarTags(int quantidade);
        IEnumerable<Comentario> GerarComentarios(int quantidade, IEnumerable<Post> posts, IEnumerable<Usuario> usuarios);
    }
}

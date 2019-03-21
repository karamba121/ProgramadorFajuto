using ProgramadorFajuto.Domain.Dominio.Entidades.Base;

namespace ProgramadorFajuto.Domain.Dominio.Entidades
{
    public class Comentario : Entidade
    {
        public Comentario() { }
        public Comentario(Post post, Usuario autor, string conteudo)
        {
            Post = post;
            Autor = autor;
            Conteudo = conteudo;
        }
        public Post Post { get; private set; }
        public Usuario Autor { get; private set; }
        public string Conteudo { get; private set; }
    }
}

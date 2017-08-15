using ProgramadorFajuto.Domain.Dominio.Entidades.Base;
using System.Collections.Generic;

namespace ProgramadorFajuto.Domain.Dominio.Entidades
{
    public class Post : Entidade
    {
        public Post(Blog blog, Usuario autor, string titulo, string descricao, string conteudo, IEnumerable<Tag> tags)
        {
            this.Blog = blog;
            this.Autor = autor;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Conteudo = conteudo;
            this.Tags = tags;
        }

        private Post() { }
        public Blog Blog { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Usuario Autor { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
    }
}

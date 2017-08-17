using ProgramadorFajuto.Domain.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;

namespace ProgramadorFajuto.Domain.Dominio.Entidades
{
    public class Post : Entidade
    {
        public Post() { }
        public Post(Blog blog, Usuario autor, string titulo, string descricao, string conteudo, IEnumerable<Tag> tags)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                throw new ArgumentException("Um objeto Post não pode ser criado com a propriedade Titulo nula ou vazia.", nameof(titulo));
            }

            if (string.IsNullOrEmpty(descricao))
            {
                throw new ArgumentException("Um objeto Post não pode ser criado com a propriedade Descricao nula ou vazia.", nameof(descricao));
            }

            if (string.IsNullOrEmpty(conteudo))
            {
                throw new ArgumentException("Um objeto Post não pode ser criado com a propriedade Conteudo nula ou vazia.", nameof(conteudo));
            }

            this.Blog = blog ?? throw new ArgumentNullException(nameof(blog));
            this.Autor = autor ?? throw new ArgumentNullException(nameof(autor));
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Conteudo = conteudo;
            this.Tags = tags ?? throw new ArgumentNullException(nameof(tags));
        }

        public Blog Blog { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Usuario Autor { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
    }
}

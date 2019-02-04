using ProgramadorFajuto.Domain.Dominio.Entidades;
using System.Collections.Generic;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Modelos
{
    public class ModeloDePost
    {
        public ModeloDePost()
        {

        }

        public ModeloDePost(IEnumerable<Post> posts, IEnumerable<Post> meusPosts)
        {
            this.Posts = posts;
            this.MeusPosts = meusPosts;
        }

        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Post> MeusPosts { get; set; }
    }
}

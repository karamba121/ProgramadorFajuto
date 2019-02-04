using ProgramadorFajuto.Application.Aplicacao.Util.Modelos.Base;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using System.Collections.Generic;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Modelos
{
    public class ModeloDeHome
    {
        public ModeloDeHome(ModeloDeLista<Post> posts, IEnumerable<Post> postsMaisPopulares)
        {
            this.Posts = posts;
            this.PostsMaisPopulares = postsMaisPopulares;
        }

        public ModeloDeLista<Post> Posts { get; set; }
        public IEnumerable<Post> PostsMaisPopulares { get; set; }
    }
}

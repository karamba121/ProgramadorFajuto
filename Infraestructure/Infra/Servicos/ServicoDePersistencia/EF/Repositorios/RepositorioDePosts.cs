using Microsoft.EntityFrameworkCore;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Domain.Dominio.Repositorios;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Repositorios
{
    public class RepositorioDePosts : RepositorioEF<Post>, IRepositorioDePosts
    {
        private readonly DbSet<Post> _set;

        public RepositorioDePosts(ContextoEF contexto) : base(contexto)
        {
            this._set = contexto.Post;
        }

        public new IEnumerable<Post> ListarTodos()
        {
            return this._set.Include(p => p.Autor).Include(p => p.Blog).Include(p => p.Tags).Include(p => p.Comentarios).ToList();
        }

        public IEnumerable<Post> ListarTodos(int pagina)
        {
            return this._set.Include(p => p.Autor).Include(p => p.Blog).Include(p => p.Tags).Include(p => p.Comentarios).Skip((pagina - 1) * 10).Take(10).ToList();
        }
    }
}

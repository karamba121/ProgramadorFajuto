using Microsoft.EntityFrameworkCore;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDePersistencia.EF.Extensions;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF
{
    public class ContextoEF : DbContext
    {
        public ContextoEF(DbContextOptions<ContextoEF> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddConfiguration(new MapeamentoDeUsuario());
            builder.AddConfiguration(new MapeamentoDePost());
            builder.AddConfiguration(new MapeamentoDeComentario());
            builder.AddConfiguration(new MapeamentoDeBlog());
            builder.AddConfiguration(new MapeamentoDeTag());
        }
    }
}

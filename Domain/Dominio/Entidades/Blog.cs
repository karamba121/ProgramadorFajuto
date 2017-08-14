using ProgramadorFajuto.Domain.Dominio.Entidades.Base;

namespace ProgramadorFajuto.Domain.Dominio.Entidades
{
    public class Blog : Entidade
    {
        private Blog() { }
        public Blog(Usuario usuario)
        {
            this.Usuario = usuario;
        }

        public Usuario Usuario { get; private set; }
    }
}

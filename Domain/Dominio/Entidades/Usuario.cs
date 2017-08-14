using ProgramadorFajuto.Domain.Dominio.Entidades.Base;

namespace ProgramadorFajuto.Domain.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        private Usuario() { }
        public Usuario(string email, string senhaCriptografada, string salt)
        {
            Email = email;
            SenhaCriptografada = senhaCriptografada;
            Salt = salt;
        }

        public string Email { get; private set; }
        public string SenhaCriptografada { get; private set; }
        public string Salt { get; private set; }
    }
}

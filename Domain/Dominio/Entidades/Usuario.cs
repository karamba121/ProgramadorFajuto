using ProgramadorFajuto.Domain.Dominio.Entidades.Base;

namespace ProgramadorFajuto.Domain.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public Usuario() { }
        public Usuario(string nome, string email, string salt, string senhaCriptografada)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new System.ArgumentException("um objeto Usuario não pode ser criado com a propriedade Nome nula ou vazia.", nameof(nome));
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new System.ArgumentException("um objeto Usuario não pode ser criado com a propriedade Email nula ou vazia.", nameof(email));
            }

            if (string.IsNullOrEmpty(senhaCriptografada))
            {
                throw new System.ArgumentException("um objeto Usuario não pode ser criado com a propriedade SenhaCriptografada nula ou vazia.", nameof(senhaCriptografada));
            }

            if (string.IsNullOrEmpty(salt))
            {
                throw new System.ArgumentException("um objeto Usuario não pode ser criado com a propriedade Salt nula ou vazia.", nameof(salt));
            }

            Nome = nome;
            Email = email;
            SenhaCriptografada = senhaCriptografada;
            Salt = salt;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaCriptografada { get; private set; }
        public string Salt { get; private set; }
    }
}

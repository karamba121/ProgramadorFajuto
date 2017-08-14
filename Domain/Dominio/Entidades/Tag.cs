using ProgramadorFajuto.Domain.Dominio.Entidades.Base;

namespace ProgramadorFajuto.Domain.Dominio.Entidades
{
    public class Tag : Entidade
    {
        private Tag() { }
        public Tag(string valor)
        {
            this.Valor = valor;
        }

        public string Valor { get; private set; }
    }
}

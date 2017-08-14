using System;

namespace ProgramadorFajuto.Domain.Dominio.Entidades.Base
{
    public class Entidade
    {
        public Entidade()
        {
            this.Inclusao = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime Inclusao { get; private set; }
    }
}

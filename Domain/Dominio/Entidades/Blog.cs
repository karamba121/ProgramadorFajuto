using ProgramadorFajuto.Domain.Dominio.Entidades.Base;
using System;

namespace ProgramadorFajuto.Domain.Dominio.Entidades
{
    public class Blog : Entidade
    {
        public Blog() { }
        public Blog(Usuario usuario)
        {
            this.Usuario = usuario ?? throw new ArgumentNullException("usuario", "Um objeto Blog não pode ser criado com um objeto Usuario nulo.");
        }

        public Usuario Usuario { get; private set; }
    }
}

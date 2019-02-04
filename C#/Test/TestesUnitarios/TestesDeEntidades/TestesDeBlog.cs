using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using System;

namespace ProgramadorFajuto.Test.TestesUnitarios.TestesDeEntidades
{
    [TestClass]
    public class TestesDeBlog
    {
        [TestMethod]
        public void BlogNaoPodeSerCriadoComUsuarioNulo()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Blog(null));
        }
    }
}

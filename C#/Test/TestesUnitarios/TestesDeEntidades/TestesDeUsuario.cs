using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using System;

namespace ProgramadorFajuto.Test.TestesUnitarios.TestesDeEntidades
{
    [TestClass]
    public class TestesDeUsuario
    {
        [TestMethod]
        public void UsuarioNaoPodeSerCriadoComNomeNuloOuVazio()
        {
            Assert.ThrowsException<ArgumentException>(() => new Usuario(null, null, null, null));
            Assert.ThrowsException<ArgumentException>(() => new Usuario("", "", "", ""));
        }

        [TestMethod]
        public void UsuarioNaoPodeSerCriadoComEmailNuloOuVazio()
        {
            Assert.ThrowsException<ArgumentException>(() => new Usuario("asdfasd", null, null, null));
            Assert.ThrowsException<ArgumentException>(() => new Usuario("asdfasd", "", "", ""));
        }

        [TestMethod]
        public void UsuarioNaoPodeSerCriadoComSenhaCriptografadaNulaOuVazia()
        {
            Assert.ThrowsException<ArgumentException>(() => new Usuario("asdfasdf", "asdfasdf", null, null));
            Assert.ThrowsException<ArgumentException>(() => new Usuario("asdfasdf", "asdfasdf", "", ""));
        }

        [TestMethod]
        public void UsuarioNaoPodeSerCriadoComSaltNuloOuVazio()
        {
            Assert.ThrowsException<ArgumentException>(() => new Usuario("asdfasdf", "asdfasdf", "asdfasdf", null));
            Assert.ThrowsException<ArgumentException>(() => new Usuario("asdfasdf", "asdfasdf", "asdfasdf", ""));
        }
    }
}

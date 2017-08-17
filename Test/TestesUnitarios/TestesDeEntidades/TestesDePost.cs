using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ProgramadorFajuto.Test.TestesUnitarios.TestesDeEntidades
{
    [TestClass]
    public class TestesDePost
    {
        [TestMethod]
        public void PostNaoPodeSerCriadoComBlogNulo()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Post(null, new Usuario(), "asdf", "asdfasd", "asdfasdf", new List<Tag>()));
        }

        [TestMethod]
        public void PostNaoPodeSerCriadoComUsuarioAutorNulo()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Post(new Blog(), null, "adfasdf", "asdfasd", "asdfasdf", new List<Tag>()));
        }

        [TestMethod]
        public void PostNaoPodeSerCriadoComTituloNuloOuVazio()
        {
            Assert.ThrowsException<ArgumentException>(() => new Post(new Blog(), new Usuario(), null, "asdfasd", "asdfasdf", new List<Tag>()));
            Assert.ThrowsException<ArgumentException>(() => new Post(new Blog(), new Usuario(), "", "asdfasd", "asdfasdf", new List<Tag>()));
        }

        [TestMethod]
        public void PostNaoPodeSerCriadoComDescricaoNulaOuVazia()
        {
            Assert.ThrowsException<ArgumentException>(() => new Post(new Blog(), new Usuario(), "asdfas", null, "asdfasdf", new List<Tag>()));
            Assert.ThrowsException<ArgumentException>(() => new Post(new Blog(), new Usuario(), "asdfasdf", "", "asdfasdf", new List<Tag>()));
        }
    }
}

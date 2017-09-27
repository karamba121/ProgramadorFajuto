using Bogus;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeGeracaoDeDados
{
    public class GeradorBogus : IServicoDeGeracaoDeDados
    {
        private readonly IServicoDeCriptografia _servicoDeCriptografia;

        public GeradorBogus(IServicoDeCriptografia servicoDeCriptografia)
        {
            this._servicoDeCriptografia = servicoDeCriptografia;
        }

        public IEnumerable<Comentario> GerarComentarios(int quantidade, IEnumerable<Post> posts, IEnumerable<Usuario> usuarios)
        {
            var faker = new Faker<Comentario>("pt_BR")
                .StrictMode(false)
                .RuleFor(p => p.Inclusao, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now))
                .RuleFor(p => p.Autor, f => f.PickRandom(usuarios))
                .RuleFor(p => p.Post, f => f.PickRandom(posts))
                .RuleFor(p => p.Conteudo, f => f.Lorem.Paragraphs(50));

            return faker.Generate(quantidade);
        }

        public IEnumerable<Post> GerarPosts(int quantidade, IEnumerable<Tag> tags, IEnumerable<Usuario> usuarios)
        {
            var faker = new Faker<Post>("pt_BR")
                .StrictMode(false)
                .RuleFor(p => p.Inclusao, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now))
                .RuleFor(p => p.Autor, f => f.PickRandom(usuarios))
                .RuleFor(p => p.Blog, (f, p) => new Blog(p.Autor))
                .RuleFor(p => p.Titulo, f => f.Lorem.Sentence())
                .RuleFor(p => p.Descricao, f => f.Lorem.Sentence())
                .RuleFor(p => p.Conteudo, f => f.Lorem.Paragraphs(50))
                .RuleFor(p => p.Tags, f => f.PickRandom(tags, f.Random.Int(1, 2)).ToList());

            return faker.Generate(quantidade);
        }

        public IEnumerable<Tag> GerarTags(int quantidade)
        {
            var faker = new Faker<Tag>("pt_BR")
                .StrictMode(false)
                .RuleFor(p => p.Valor, f => f.Lorem.Word());

            return faker.Generate(quantidade);
        }

        public IEnumerable<Usuario> GerarUsuarios(int quantidade)
        {
            var faker = new Faker<Usuario>("pt_BR")
                .StrictMode(false)
                .RuleFor(p => p.Nome, f => f.Name.FirstName())
                .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.Nome))
                .RuleFor(p => p.Salt, f => this._servicoDeCriptografia.ObterSalt())
                .RuleFor(p => p.SenhaCriptografada, (f, p) => this._servicoDeCriptografia.ObterHash("teste123" + p.Salt));

            return faker.Generate(quantidade);
        }
    }
}

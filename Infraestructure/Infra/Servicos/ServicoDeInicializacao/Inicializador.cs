using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System.Collections.Generic;
using System.Linq;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeInicializacao
{
    public class Inicializador : IServicoDeInicializacao
    {
        private readonly IServicoDePersistencia _servicoDePersistencia;
        private readonly IServicoDeCriptografia _servicoDeCriptografia;

        public Inicializador(IServicoDePersistencia servicoDePersistencia, IServicoDeCriptografia servicoDeCriptografia)
        {
            this._servicoDePersistencia = servicoDePersistencia;
            this._servicoDeCriptografia = servicoDeCriptografia;
        }

        public void GG()
        {
            if (!this._servicoDePersistencia.RepositorioDePosts.ListarTodos().Any())
            {
                var salt = this._servicoDeCriptografia.ObterSalt();
                var senha = this._servicoDeCriptografia.ObterHash("@Stag121" + salt);
                var usuario = new Usuario("Matheus", "matheus.stag@gmail.com", senha, salt);
                var blog = new Blog(usuario);
                var tags = new List<Tag>()
                {
                    new Tag("Teste"),
                    new Tag("Outra tag")
                };

                var post = new Post(blog, usuario, "Lorem Ipsum", "dollor sit amet nor ed sictium", "falksdj faklsdjf asdkfj asldkjfas dfjadlkfjadlkfjas dfjasdlkfjasldkfj asdlkfjas dlfalksdjflaksdjf aslkdjfaslkdfja dkfja sdfa sdfjaskld fjaslkçd faskdj fasd", tags);

                this._servicoDePersistencia.RepositorioDePosts.Adicionar(post);
                this._servicoDePersistencia.Persistir();
            }
        }
    }
}

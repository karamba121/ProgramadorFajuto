using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System.Linq;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeInicializacao
{
    public class Inicializador : IServicoDeInicializacao
    {
        private readonly IServicoDePersistencia _servicoDePersistencia;
        private readonly IServicoDeCriptografia _servicoDeCriptografia;
        private readonly IServicoDeGeracaoDeDados _servicoDeGeracaoDeDados;

        public Inicializador(IServicoDePersistencia servicoDePersistencia, IServicoDeCriptografia servicoDeCriptografia, IServicoDeGeracaoDeDados servicoDeGeracaoDeDados)
        {
            this._servicoDePersistencia = servicoDePersistencia;
            this._servicoDeCriptografia = servicoDeCriptografia;
            this._servicoDeGeracaoDeDados = servicoDeGeracaoDeDados;
        }

        public void GG()
        {
            if (!this._servicoDePersistencia.RepositorioDePosts.ListarTodos().Any())
            {
                var usuarios = this._servicoDeGeracaoDeDados.GerarUsuarios(200);

                this._servicoDePersistencia.RepositorioDeUsuarios.Adicionar(usuarios);
                this._servicoDePersistencia.Persistir();

                var tags = this._servicoDeGeracaoDeDados.GerarTags(50);

                this._servicoDePersistencia.RepositorioDeTags.Adicionar(tags);
                this._servicoDePersistencia.Persistir();

                var posts = this._servicoDeGeracaoDeDados.GerarPosts(1000, tags, usuarios);

                this._servicoDePersistencia.RepositorioDePosts.Adicionar(posts);
                this._servicoDePersistencia.Persistir();

                var comentarios = this._servicoDeGeracaoDeDados.GerarComentarios(10, posts, usuarios);

                this._servicoDePersistencia.RepositorioDeComentarios.Adicionar(comentarios);
                this._servicoDePersistencia.Persistir();
            }
        }
    }
}

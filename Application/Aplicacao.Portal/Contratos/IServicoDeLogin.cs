using ProgramadorFajuto.Application.Aplicacao.Portal.Modelos;
using System.Threading.Tasks;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Contratos
{
    public interface IServicoDeLogin
    {
        Task AutenticarAsync(ModeloDeLogin modeloDeLogin);
        Task DeslogarAsync();
        Task CadastrarAsync(string nome, string email, string senha);
    }
}

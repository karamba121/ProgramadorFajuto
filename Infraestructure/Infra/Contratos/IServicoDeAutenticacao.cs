using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgramadorFajuto.Infraestructure.Infra.Contratos
{
    public interface IServicoDeAutenticacao
    {
        Task AutenticarAsync(IDictionary<string, object> parametros);
        Task DeslogarAsync();
    }
}

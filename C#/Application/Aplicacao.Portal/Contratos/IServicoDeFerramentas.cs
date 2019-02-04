using Microsoft.AspNetCore.Http;
using System.IO;

namespace ProgramadorFajuto.Application.Aplicacao.Portal.Contratos
{
    public interface IServicoDeFerramentas
    {
        Stream Formatar(IFormFile arquivo);
    }
}

using Microsoft.AspNetCore.Http;
using System.IO;

namespace ProgramadorFajuto.Infraestructure.Infra.Contratos
{
    public interface IServicoDeFormatacaoDeEmail
    {
        Stream Formatar(IFormFile arquivo);
    }
}

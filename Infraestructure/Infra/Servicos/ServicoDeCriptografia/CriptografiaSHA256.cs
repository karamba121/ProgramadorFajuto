using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeCriptografia
{
    public class CriptografiaSHA256 : IServicoDeCriptografia
    {
        public string ObterHash(string valor)
        {
            using (var sha256 = SHA256.Create())
            {
                var senha = sha256.ComputeHash(Encoding.UTF8.GetBytes(valor));

                return BitConverter.ToString(senha).Replace("-", "").ToLower();
            }
        }

        public string ObterSalt()
        {
            byte[] bytes = new byte[128 / 8];
            using (var chave = RandomNumberGenerator.Create())
            {
                chave.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}

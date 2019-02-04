namespace ProgramadorFajuto.Infraestructure.Infra.Contratos
{
    public interface IServicoDeCriptografia
    {
        string ObterSalt();
        string ObterHash(string valor);
    }
}

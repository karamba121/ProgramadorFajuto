using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos.Base
{
    public abstract class MapeamentoEF<T> where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> builder);
    }
}

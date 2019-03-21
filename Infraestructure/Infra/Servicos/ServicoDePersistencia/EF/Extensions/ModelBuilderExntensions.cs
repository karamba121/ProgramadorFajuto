using Microsoft.EntityFrameworkCore;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos.Base;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDePersistencia.EF.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<T>(this ModelBuilder modelBuilder, MapeamentoEF<T> configuracao) where T : class => configuracao.Map(modelBuilder.Entity<T>());
    }
}

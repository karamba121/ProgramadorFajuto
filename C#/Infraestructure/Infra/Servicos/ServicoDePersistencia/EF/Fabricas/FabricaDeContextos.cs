using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Fabricas
{
    public class FabricaDeContextos : IDesignTimeDbContextFactory<ContextoEF>
    {
        public FabricaDeContextos() { }

        public ContextoEF CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ContextoEF>();

            options.UseSqlServer($"Data Source = (LocalDb)\\localhost; initial catalog = ProgramadorFajuto; user id = sa; password = a;");

            return new ContextoEF(options.Options);
        }
    }
}

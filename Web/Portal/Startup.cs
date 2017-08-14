using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramadorFajuto.Application.Aplicacao.Util;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF;

namespace ProgramadorFajuto.Web.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<VariaveisDeAmbiente>(this.Configuration);
            services.AddDbContext<ContextoEF>(options => { options.UseSqlServer(this.Configuration.GetValue<string>("ConnectionString")); });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}

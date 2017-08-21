using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;
using ProgramadorFajuto.Application.Aplicacao.Portal.Servicos;
using ProgramadorFajuto.Application.Aplicacao.Util;
using ProgramadorFajuto.Infraestructure.Infra.Contratos;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeAutenticacao;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeCriptografia;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeFormatacaoDeEmail;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeGeracaoDeDados;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.ServicoDeInicializacao;
using System;
using System.IO.Compression;
using System.Linq;

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
            services.AddOptions();
            services.Configure<VariaveisDeAmbiente>(this.Configuration);
            services.AddDbContext<ContextoEF>(options => { options.UseSqlServer(this.Configuration.GetValue<string>("ConnectionString")); });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o =>
            {
                o.LoginPath = new PathString("/Login/Index/");
                o.LogoutPath = new PathString("/Login/Deslogar/");
            });

            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddResponseCaching();

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    "image/svg+xml",
                    "application/atom+xml",
                    "application/x-font-ttf"
                });
            });

            services.AddMvc();

            services.AddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));

            services.AddScoped(typeof(IServicoDeInicializacao), typeof(Inicializador));
            services.AddScoped(typeof(IServicoDePersistencia), typeof(UnidadeDeTrabalhoEF));
            services.AddScoped(typeof(IServicoDeCriptografia), typeof(CriptografiaSHA256));
            services.AddScoped(typeof(IServicoDeAutenticacao), typeof(AutenticacaoPorCookie));
            services.AddScoped(typeof(IServicoDeFormatacaoDeEmail), typeof(FormatadorPhotoshop));
            services.AddScoped(typeof(IServicoDeGeracaoDeDados), typeof(GeradorBogus));

            services.AddScoped(typeof(IServicoDeLogin), typeof(ServicoDeLogin));
            services.AddScoped(typeof(IServicoDeHome), typeof(ServicoDeHome));
            services.AddScoped(typeof(IServicoDeFerramentas), typeof(ServicoDeFerramentas));
            services.AddScoped(typeof(IServicoDePost), typeof(ServicoDePost));
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseResponseCompression();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = prepareResponse =>
                {
                    prepareResponse.Context.Response.Headers[HeaderNames.CacheControl] = "public, max-age=31622400";
                }
            });

            app.UseSession();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            serviceProvider.GetService<IServicoDeInicializacao>().GG();
        }
    }
}

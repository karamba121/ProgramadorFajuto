using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos.Base;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos
{
    public class MapeamentoDePost : MapeamentoEF<Post>
    {
        public override void Map(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(p => p.Id);
        }
    }
}

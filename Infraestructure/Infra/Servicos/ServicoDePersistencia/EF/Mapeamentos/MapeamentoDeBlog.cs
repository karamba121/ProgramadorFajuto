using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos.Base;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos
{
    public class MapeamentoDeBlog : MapeamentoEF<Blog>
    {
        public override void Map(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog");
            builder.HasKey(p => p.Id);
        }
    }
}

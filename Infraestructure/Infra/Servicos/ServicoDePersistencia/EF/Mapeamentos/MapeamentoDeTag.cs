using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos.Base;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos
{
    public class MapeamentoDeTag : MapeamentoEF<Tag>
    {
        public override void Map(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Tag");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos.Base;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos
{
    public class MapeamentoDeComentario : MapeamentoEF<Comentario>
    {
        public override void Map(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(p => p.Id);
        }
    }
}

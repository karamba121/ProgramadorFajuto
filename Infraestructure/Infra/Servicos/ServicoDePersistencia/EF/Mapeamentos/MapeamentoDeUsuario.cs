using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos.Base;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Mapeamentos
{
    public class MapeamentoDeUsuario : MapeamentoEF<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id);
        }
    }
}

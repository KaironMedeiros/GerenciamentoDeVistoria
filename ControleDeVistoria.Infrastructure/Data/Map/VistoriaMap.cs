using ControleDeVistoria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeVistoria.Infra.IoC.Data.Map
{
    public class VistoriaMap : IEntityTypeConfiguration<Vistoria>
    {
        public void Configure(EntityTypeBuilder<Vistoria> builder)
        {
            builder.HasOne(x => x.Vistoriador).WithMany(x => x.Vistoria).HasForeignKey(x => x.VistoriadorId);
            builder.HasOne(x => x.Imovel).WithOne(x => x.Vistoria).HasForeignKey<Vistoria>(x => x.ImovelId);
        }
    }
}

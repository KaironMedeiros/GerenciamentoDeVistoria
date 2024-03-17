using ControleDeVistoria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeVistoria.Infra.IoC.Data.Map
{
    public class LocatarioMap : IEntityTypeConfiguration<Locatario>
    {
        public void Configure(EntityTypeBuilder<Locatario> builder)
        {
            builder.HasOne(x => x.Imovel).WithOne(x => x.Locatario).HasForeignKey<Locatario>(x => x.ImovelId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

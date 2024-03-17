using ControleDeVistoria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeVistoria.Infra.IoC.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder) 
        {
            builder.HasOne(x => x.Imovel).WithOne(x => x.Endereco).HasForeignKey<Endereco>(x => x.ImovelId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

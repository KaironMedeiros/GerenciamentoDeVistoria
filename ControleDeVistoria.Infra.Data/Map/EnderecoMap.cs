using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ControleDeVistoria.Domain.Entities;

namespace VistoriaApp.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder) 
        {
            builder.HasOne(x => x.Imovel).WithOne(x => x.Endereco).HasForeignKey<Endereco>(x => x.ImovelId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

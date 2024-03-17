using Microsoft.EntityFrameworkCore;
using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Infra.IoC.Data.Map;

namespace ControleDeVistoria.Infra.IoC.Data
{
    public class VistoriaContext : DbContext
    {
        public VistoriaContext(DbContextOptions<VistoriaContext> options) : base(options) { }

        public DbSet<Ambiente> Ambientes { get; set;}
        public DbSet<Endereco> Enderecos { get; set;}
        public DbSet<Imovel> Imoveis { get; set;}
        public DbSet<Locatario> Locatarios { get; set;}
        public DbSet<Vistoriador> Vistoriadores { get; set;}
        public DbSet<Vistoria> Vistorias { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new LocatarioMap());
            modelBuilder.ApplyConfiguration(new VistoriaMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}

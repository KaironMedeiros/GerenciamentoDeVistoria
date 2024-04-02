using Microsoft.EntityFrameworkCore;
using VistoriaApp.Data.Map;
using ControleDeVistoria.Domain.Entities;

namespace VControleDeVistoria.Infra.Data.Context
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

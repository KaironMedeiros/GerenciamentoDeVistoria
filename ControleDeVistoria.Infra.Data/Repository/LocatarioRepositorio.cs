using Microsoft.EntityFrameworkCore;
using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Interface;
using VControleDeVistoria.Infra.Data.Context;

namespace ControleDeVistoria.Infra.IoC.Repository
{
    public class LocatarioRepositorio : ILocatarioRepositorio
    {
        private readonly VistoriaContext _context;

        public LocatarioRepositorio(VistoriaContext context)
        {
            _context = context;
        }

        public Locatario Adicionar(Locatario locatario)
        {
            _context.Locatarios.Add(locatario);
            _context.SaveChanges();
            return locatario;
        }

        public async Task<Locatario> BuscarPorFK(int id)
        {
            return await _context.Locatarios.FirstOrDefaultAsync(x => x.ImovelId == id);
        }

        public async Task<Imovel> BuscarPorIdImovel(int id)
        {
            return await _context.Imoveis.Include(x => x.Locatario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Locatario Atualizar(Locatario locatario)
        {
            Locatario locatarioDb = BuscarPorFK(locatario.ImovelId).Result;

            if (locatarioDb == null) throw new System.Exception("Houve um erro na atualização dos dados");

            locatarioDb.Nome = locatario.Nome;
            locatarioDb.CPF = locatario.CPF;
            locatarioDb.Telefone = locatario.Telefone;
            locatarioDb.DataEntrada = locatario.DataEntrada;
            locatarioDb.DataSaida = locatario.DataSaida;

            _context.Locatarios.Update(locatarioDb);
            _context.SaveChanges();

            return locatarioDb;

        }

        public bool Excluir(Locatario locatario)
        {
            _context.Locatarios.Remove(locatario);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Locatarios.Any(x => x.ImovelId == id);
        }

        
    }
}

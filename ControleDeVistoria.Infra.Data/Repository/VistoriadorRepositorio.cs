using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using VControleDeVistoria.Infra.Data.Context;

namespace ControleDeVistoria.Infra.IoC.Repository
{

    public class VistoriadorRepositorio : IVistoriadorRepositorio
    {
        private readonly VistoriaContext _context;

        public VistoriadorRepositorio(VistoriaContext context) 
        {
            _context = context;
        }

        public Vistoriador Adicionar(Vistoriador vistoriador)
        {
            _context.Vistoriadores.Add(vistoriador);
            _context.SaveChanges();
            return vistoriador;
        }

        public async Task<Vistoriador> BuscarPorId(int id)
        {
            return await _context.Vistoriadores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Vistoriador>> BuscarTodos()
        {
            return await _context.Vistoriadores.ToListAsync();
        }

        public Vistoriador Atualizar(Vistoriador vistoriador)
        {
            Vistoriador vistoriadorDb = BuscarPorId(vistoriador.Id).Result;

            if (vistoriadorDb == null) throw new System.Exception("Houve um erro na atualização dos dados");

            vistoriadorDb.Nome = vistoriador.Nome;
            vistoriadorDb.Telefone = vistoriador.Telefone;
            vistoriadorDb.Email = vistoriador.Email;


            _context.Vistoriadores.Update(vistoriadorDb);
            _context.SaveChanges();

            return vistoriadorDb;
        }

        public bool Excluir(Vistoriador vistoriador)
        {

            _context.Vistoriadores.Remove(vistoriador);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Vistoriadores.Any(x => x.Id == id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Interface;
using VControleDeVistoria.Infra.Data.Context;

namespace ControleDeVistoria.Infra.Data.Repository
{

    public class AmbienteRepositorio : IAmbienteRepositorio
    {
        private readonly VistoriaContext _context;

        public AmbienteRepositorio(VistoriaContext context) 
        {
            _context = context;
        }

        public Ambiente Adicionar(Ambiente ambiente)
        {
            _context.Ambientes.Add(ambiente);
            _context.SaveChanges();
            return ambiente;
        }

        public async Task<Ambiente> BuscarPorId(int id)
        {
            return await _context.Ambientes.FirstOrDefaultAsync(x => x.Id == id);
        }

       /* public ICollection<AmbienteModel> BuscarTodos()
        {
            return _context.Ambiente.ToList();
        }*/

        public bool Excluir(Ambiente ambienteDb)
        {
            _context.Ambientes.Remove(ambienteDb);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Ambientes.Any(x => x.Id == id);
        }
    }
}

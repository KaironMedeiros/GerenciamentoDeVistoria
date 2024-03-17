using Microsoft.EntityFrameworkCore;
using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Infra.IoC.Data;
using ControleDeVistoria.Infra.IoC.Repository.Interface;

namespace ControleDeVistoria.Infra.IoC.Repository
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

        public Ambiente BuscarPorId(int id)
        {
            return _context.Ambientes.FirstOrDefault(x => x.Id == id);
        }

       /* public ICollection<AmbienteModel> BuscarTodos()
        {
            return _context.Ambiente.ToList();
        }*/

        public bool Excluir(int id)
        {
            Ambiente ambienteDb = BuscarPorId(id);

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

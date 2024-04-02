using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Interface;
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

        public Vistoriador BuscarPorId(int id)
        {
            return _context.Vistoriadores.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Vistoriador> BuscarTodos()
        {
            return _context.Vistoriadores.ToList();
        }

        public Vistoriador Atualizar(Vistoriador vistoriador)
        {
            Vistoriador vistoriadorDb = BuscarPorId(vistoriador.Id);

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

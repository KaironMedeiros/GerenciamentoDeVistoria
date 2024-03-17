using Microsoft.EntityFrameworkCore;
using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Infra.IoC.Repository.Interface;
using ControleDeVistoria.Infra.IoC.Data;

namespace ControleDeVistoria.Infra.IoC.Repository
{

    public class ImovelRepositorio : IImovelRepositorio
    {
        private readonly VistoriaContext _context;

        public ImovelRepositorio(VistoriaContext context) 
        {
            _context = context;
        }

        public Imovel Adicionar(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            _context.SaveChanges();
            return imovel;
        }

        public Imovel BuscarPorId(int id)
        {
            return _context.Imoveis.Include(x => x.Endereco).Include(x => x.Locatario).FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Imovel> BuscarTodos()
        {
            return _context.Imoveis.Include(x => x.Endereco).Include(x => x.Vistoria).Include(x => x.Locatario).ToList();
        }

        public Imovel Atualizar(Imovel imovel)
        {
            Imovel imovelDb = BuscarPorId(imovel.Id);

            if (imovelDb == null) throw new System.Exception("Houve um erro na atualização dos dados");

            //imovelDb.TipoImovel = imovel.TipoImovel;
            //imovelDb.Situacao = imovel.Situacao;
            imovelDb.Endereco.UF = imovel.Endereco.UF;
            imovelDb.Endereco.Cidade = imovel.Endereco.Cidade;
            imovelDb.Endereco.Bairro = imovel.Endereco.Bairro;
            imovelDb.Endereco.Rua = imovel.Endereco.Rua;
            imovelDb.Endereco.Numero = imovel.Endereco.Numero;
            imovelDb.Endereco.CEP = imovel.Endereco.CEP;
            imovelDb.Endereco.Complemento = imovel.Endereco.Complemento;

            _context.Imoveis.Update(imovelDb);
            _context.SaveChanges();

            return imovelDb;
        }

        public bool Excluir(int id)
        {
            Imovel imovelDb = BuscarPorId(id);

            _context.Imoveis.Remove(imovelDb);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Imoveis.Any(x => x.Id == id);
        }

        public ICollection<Imovel> BuscarPorUsuario()
        {
           
            return _context.Imoveis.Include(x => x.Endereco).Include(x => x.Vistoria).Include(x => x.Locatario).ToList();
        }
    }
}

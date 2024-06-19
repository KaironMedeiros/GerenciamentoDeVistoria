using Microsoft.EntityFrameworkCore;
using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Interface;
using VControleDeVistoria.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using ControleDeVistoria.Infra.Data.IdentityData.Data;
using Microsoft.AspNetCore.Http;

namespace ControleDeVistoria.Infra.IoC.Repository
{

    public class ImovelRepositorio : IImovelRepositorio
    {
        private readonly VistoriaContext _context;
        private readonly UserManager<ControleDeVistoriaIdentityUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
         
        public ImovelRepositorio(VistoriaContext context, UserManager<ControleDeVistoriaIdentityUser> userManager, IHttpContextAccessor httpContextAccessor) 
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = httpContextAccessor;
        }

        public Imovel Adicionar(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            _context.SaveChanges();
            return imovel;
        }

        public async Task<Imovel> BuscarPorId(int id)
        {
            return await _context.Imoveis.Include(x => x.Endereco).Include(x => x.Locatario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Imovel>> BuscarTodos()
        {
            return await _context.Imoveis.Include(x => x.Endereco).Include(x => x.Vistoria).Include(x => x.Locatario).ToListAsync();
        }

        public Imovel Atualizar(Imovel imovel)
        {
            Imovel imovelDb = BuscarPorId(imovel.Id).Result;

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

        public bool Excluir(Imovel imovel)
        {

            _context.Imoveis.Remove(imovel);
            _context.SaveChanges();

            return true;
        }

        public bool IdExiste(int id)
        {
            return _context.Imoveis.Any(x => x.Id == id);
        }

        public async Task<ICollection<Imovel>> BuscarPorUsuario()
        {
            string IdUserLog = _userManager.GetUserId(_contextAccessor.HttpContext.User);         
            return await _context.Imoveis.Where(x => x.IdUser == IdUserLog).Include(x => x.Endereco).Include(x => x.Vistoria).Include(x => x.Locatario).ToListAsync();
        }
    }
}

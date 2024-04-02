using Microsoft.EntityFrameworkCore;
using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Interface;
using VControleDeVistoria.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ControleDeVistoria.Infra.Data.IdentityData.Data;

namespace ControleDeVistoria.Infra.IoC.Repository
{
    public class VistoriaRepositorio : IVistoriaRepositorio
    {
        private readonly VistoriaContext _context;
        private readonly UserManager<ControleDeVistoriaIdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VistoriaRepositorio(VistoriaContext context)
        {
            _context = context;
        }

        public Vistoria Adicionar(Vistoria vistoria)
        {
            _context.Vistorias.Add(vistoria);
            _context.SaveChanges();
            return(vistoria);
        }

        public Vistoria Atualizar(Vistoria vistoria)
        {
            Vistoria vistoriaDb = BuscarPorId(vistoria.Id);

            if(vistoriaDb == null) throw new System.Exception("Houve um erro na atualização dos dados");
            {
               // vistoriaDb.TipoVistoria = vistoria.TipoVistoria;
                vistoriaDb.MedidorAgua = vistoria.MedidorAgua;
                vistoriaDb.MedidorEnergia = vistoria.MedidorEnergia;
                vistoriaDb.DataVistoria = vistoria.DataVistoria;

                _context.Vistorias.Update(vistoriaDb);
                _context.SaveChanges();

                return vistoriaDb;
            }
        }

        public Vistoria BuscarPorId(int id) 
        {
            return _context.Vistorias.Include(x => x.Imovel.Endereco).Include(x => x.Imovel.Locatario).Include(x => x.Vistoriador).Include(x => x.Ambiente).FirstOrDefault(x => x.Id == id);
        }

        public Vistoria BuscarPorIdImovel(int ImovelId)
        {
            return _context.Vistorias.FirstOrDefault(x => x.ImovelId == ImovelId);
        }

        public Vistoriador BuscarPorIdVistoriador(int id) 
        {
            return _context.Vistoriadores.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Vistoria> BuscarTodos()
        {
            return _context.Vistorias.Include(x => x.Imovel.Endereco).Include(x => x.Imovel.Locatario).Include(x => x.Vistoriador).ToList();
        }

        public ICollection<Ambiente> BuscarAmbientes(int vistoriaId)
        {
            return _context.Ambientes.Where(x => x.VistoriaId == vistoriaId).ToList();
        }

        public bool Excluir(Vistoria vistoria)
        {
            _context.Remove(vistoria);
            _context.SaveChanges();

            return true;

        }

        public bool IdExiste(int id)
        {
            return _context.Vistorias.Any(x => x.Id == id);
        }

        public ICollection<Vistoria> BuscarPorUsuario()
        {
            string IdUserLog = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return _context.Vistorias.Where(x => x.IdUser == IdUserLog).Include(x => x.Imovel.Endereco).Include(x => x.Imovel.Locatario).Include(x => x.Vistoriador).ToList();
        }
    }
}

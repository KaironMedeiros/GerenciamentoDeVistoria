using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.Interfaces
{
    public interface IImovelService
    {
        Task<ImovelViewModel> BuscarPorId(int id); 
        Task<ICollection<ImovelViewModel>> BuscarTodos();
        Task<ICollection<ImovelViewModel>> BuscarPorUsuario();
        void Atualizar(ImovelViewModel imovel);
        void Adicionar(ImovelViewModel imovel);
        bool IdExiste(int id);
        void Excluir(int id);
    }
}

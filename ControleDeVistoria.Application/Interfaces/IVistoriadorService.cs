using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.Interfaces
{
    public interface IVistoriadorService
    {
        Task<VistoriadorViewModel> BuscarPorId(int id);
        Task<ICollection<VistoriadorViewModel>> BuscarTodos();
        void Atualizar(VistoriadorViewModel vistoriador);
        void Adicionar(VistoriadorViewModel vistoriador);
        bool IdExiste(int id);
        void Excluir(int id);
    }
}

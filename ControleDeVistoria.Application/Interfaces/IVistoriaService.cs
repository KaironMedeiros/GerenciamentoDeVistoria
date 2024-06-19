using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.Interfaces
{
    public interface IVistoriaService
    {
        Task<VistoriaViewModel> BuscarPorId(int id);
        Task<VistoriaViewModel> BuscarPorIdImovel(int id);
        Task<VistoriadorViewModel> BuscarPorIdVistoriador(int id);
        Task<ICollection<VistoriaViewModel>> BuscarPorUsuario();
        Task<ICollection<VistoriaViewModel>> BuscarTodos();
        Task<ICollection<AmbienteViewModel>> BuscarAmbientes(int vistoriaId);
        void Adicionar(VistoriaViewModel vistoria);
        void Atualizar(VistoriaViewModel vistoria);
        bool IdExiste(int id);
        void Excluir(int id);
    }
}

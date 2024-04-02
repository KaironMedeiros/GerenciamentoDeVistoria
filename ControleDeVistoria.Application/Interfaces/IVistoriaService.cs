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
        VistoriaViewModel BuscarPorId(int id);
        VistoriaViewModel BuscarPorIdImovel(int id);
        VistoriadorViewModel BuscarPorIdVistoriador(int id);
        ICollection<VistoriaViewModel> BuscarPorUsuario();
        ICollection<VistoriaViewModel> BuscarTodos();
        ICollection<AmbienteViewModel> BuscarAmbientes(int vistoriaId);
        void Adicionar(VistoriaViewModel vistoria);
        void Atualizar(VistoriaViewModel vistoria);
        bool IdExiste(int id);
        void Excluir(int id);
    }
}

using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.Interfaces
{
    public interface ILocatarioService
    {
        Task<LocatarioViewModel> BuscarPorFK(int id);
        Task<ImovelViewModel> BuscarPorIdImovel(int id);
        void Atualizar(LocatarioViewModel locatario);
        void Adicionar(LocatarioViewModel locatario);
        bool IdExiste(int id);
        void Excluir(int id);
    }
}

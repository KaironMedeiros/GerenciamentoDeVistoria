using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.Interfaces
{
    public interface IAmbienteService
    {
        Task<AmbienteViewModel> BuscarPorId(int id);
        void Adicionar(AmbienteViewModel ambiente);
        bool IdExiste(int id);
        void Excluir(int id);
    }
}

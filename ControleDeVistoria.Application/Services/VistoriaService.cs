using AutoMapper;
using ControleDeVistoria.Application.Interfaces;
using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.Services
{
    public class VistoriaService : IVistoriaService
    {
        private IVistoriaRepositorio _vistoriaRepositorio;
        private readonly IMapper _mapper;

        public VistoriaViewModel BuscarPorId(int id)
        {
            var vistoria = _vistoriaRepositorio.BuscarPorId(id);
            return _mapper.Map<VistoriaViewModel>(vistoria);
        }

        public VistoriaViewModel BuscarPorIdImovel(int id)
        {
            var vistoria = _vistoriaRepositorio.BuscarPorIdImovel(id);
            return _mapper.Map<VistoriaViewModel>(vistoria);
        }

        public VistoriadorViewModel BuscarPorIdVistoriador(int id)
        {
            var vistoria = _vistoriaRepositorio.BuscarPorIdVistoriador(id);
            return _mapper.Map<VistoriadorViewModel>(vistoria);
        }

        public ICollection<VistoriaViewModel> BuscarPorUsuario()
        {
            var vistorias = _vistoriaRepositorio.BuscarPorUsuario();
            return _mapper.Map<ICollection<VistoriaViewModel>>(vistorias);

        }

        public ICollection<VistoriaViewModel> BuscarTodos()
        {
            var vistorias = _vistoriaRepositorio.BuscarTodos();
            return _mapper.Map<ICollection<VistoriaViewModel>>(vistorias);
        }

        public ICollection<AmbienteViewModel> BuscarAmbientes(int vistoriaId)
        {
            var ambientes = _vistoriaRepositorio.BuscarAmbientes(vistoriaId);
            return _mapper.Map<ICollection<AmbienteViewModel>>(ambientes);
        }

        public void Adicionar(VistoriaViewModel vistoria)
        {
            var mapVistoria = _mapper.Map<Vistoria>(vistoria);
            _vistoriaRepositorio.Adicionar(mapVistoria);
        }

        public void Atualizar(VistoriaViewModel vistoria)
        {
            var mapVistoria = _mapper.Map<Vistoria>(vistoria);
            _vistoriaRepositorio.Atualizar(mapVistoria);
        }

        public bool IdExiste(int id)
        {
            return _vistoriaRepositorio.IdExiste(id);
        }

        public void Excluir(int id)
        {
            var vistoria = _vistoriaRepositorio.BuscarPorId(id);
            _vistoriaRepositorio.Excluir(vistoria);
        }
    }
}

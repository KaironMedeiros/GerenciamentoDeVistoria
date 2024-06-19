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

        public VistoriaService(IVistoriaRepositorio vistoriaRepositorio, IMapper mapper)
        {
            _vistoriaRepositorio = vistoriaRepositorio;
            _mapper = mapper;
        }

        public async Task<VistoriaViewModel> BuscarPorId(int id)
        {
            var vistoria = await _vistoriaRepositorio.BuscarPorId(id);
            return _mapper.Map<VistoriaViewModel>(vistoria);
        }

        public async Task<VistoriaViewModel> BuscarPorIdImovel(int id)
        {
            var vistoria = await _vistoriaRepositorio.BuscarPorIdImovel(id);
            return _mapper.Map<VistoriaViewModel>(vistoria);
        }

        public async Task<VistoriadorViewModel> BuscarPorIdVistoriador(int id)
        {
            var vistoria = await _vistoriaRepositorio.BuscarPorIdVistoriador(id);
            return _mapper.Map<VistoriadorViewModel>(vistoria);
        }

        public async Task<ICollection<VistoriaViewModel>> BuscarPorUsuario()
        {
            var vistorias = await _vistoriaRepositorio.BuscarPorUsuario();
            return _mapper.Map<ICollection<VistoriaViewModel>>(vistorias);

        }

        public async Task<ICollection<VistoriaViewModel>> BuscarTodos()
        {
            var vistorias = await _vistoriaRepositorio.BuscarTodos();
            return _mapper.Map<ICollection<VistoriaViewModel>>(vistorias);
        }

        public async Task<ICollection<AmbienteViewModel>> BuscarAmbientes(int vistoriaId)
        {
            var ambientes = await _vistoriaRepositorio.BuscarAmbientes(vistoriaId);
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
            var vistoria = _vistoriaRepositorio.BuscarPorId(id).Result;
            _vistoriaRepositorio.Excluir(vistoria);
        }
    }
}

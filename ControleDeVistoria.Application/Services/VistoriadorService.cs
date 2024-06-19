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
    public class VistoriadorService : IVistoriadorService
    {
        private IVistoriadorRepositorio _vistoriadorRepositorio;
        private readonly IMapper _mapper;

        public VistoriadorService(IVistoriadorRepositorio vistoriadorRepositorio, IMapper mapper)
        {
            _vistoriadorRepositorio = vistoriadorRepositorio;
            _mapper = mapper;

        }

        public void Adicionar(VistoriadorViewModel vistoriador)
        {
            var mapVistoriador = _mapper.Map<Vistoriador>(vistoriador);
            _vistoriadorRepositorio.Adicionar(mapVistoriador);
        }

        public void Atualizar(VistoriadorViewModel vistoriador)
        {
            var mapVistoriador = _mapper.Map<Vistoriador>(vistoriador);
            _vistoriadorRepositorio.Atualizar(mapVistoriador);
        }

        public async Task<VistoriadorViewModel> BuscarPorId(int id)
        {
            var vistoriador = await _vistoriadorRepositorio.BuscarPorId(id);
            return _mapper.Map<VistoriadorViewModel>(vistoriador);
        }

        public async Task<ICollection<VistoriadorViewModel>> BuscarTodos()
        {
            var vistoriadores = await _vistoriadorRepositorio.BuscarTodos();
            return _mapper.Map<ICollection<VistoriadorViewModel>>(vistoriadores);
        }

        public void Excluir(int id)
        {
            var vistoriador = _vistoriadorRepositorio.BuscarPorId(id).Result;
            _vistoriadorRepositorio.Excluir(vistoriador);
        }

        public bool IdExiste(int id)
        {
            return _vistoriadorRepositorio.IdExiste(id);
        }
    }
}

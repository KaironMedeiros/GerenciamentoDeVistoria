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
    public class LocatarioService : ILocatarioService
    {
        private ILocatarioRepositorio _locatarioRepositorio;
        private readonly IMapper _mapper;

        public LocatarioService(ILocatarioRepositorio locatarioRepositorio, IMapper mapper)
        {
            _locatarioRepositorio = locatarioRepositorio;
            _mapper = mapper;
        }

        public void Adicionar(LocatarioViewModel locatario)
        {
            var mapLocatario = _mapper.Map<Locatario>(locatario);
            _locatarioRepositorio.Adicionar(mapLocatario);
        }

        public void Atualizar(LocatarioViewModel locatario)
        {
            var mapLocatario = _mapper.Map<Locatario>(locatario);
            _locatarioRepositorio.Atualizar(mapLocatario);
        }

        public async Task<LocatarioViewModel> BuscarPorFK(int id)
        {
            var result = await _locatarioRepositorio.BuscarPorFK(id);
            return _mapper.Map<LocatarioViewModel>(result);
        }

        public async Task<ImovelViewModel> BuscarPorIdImovel(int id)
        {
            var result = await _locatarioRepositorio.BuscarPorIdImovel(id);
            return _mapper.Map<ImovelViewModel>(result);
        }

        public void Excluir(int id)
        {
            var locatario = _locatarioRepositorio.BuscarPorFK(id).Result;
            _locatarioRepositorio.Excluir(locatario);
        }

        public bool IdExiste(int id)
        {
            return _locatarioRepositorio.IdExiste(id);
        }
    }
}

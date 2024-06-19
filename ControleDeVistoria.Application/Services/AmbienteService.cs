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
    public class AmbienteService : IAmbienteService
    {
        private IAmbienteRepositorio _ambienteRepositorio;
        private readonly IMapper _mapper;

        public AmbienteService(IAmbienteRepositorio ambienteRepositorio, IMapper mapper)
        {
            _ambienteRepositorio = ambienteRepositorio;
            _mapper = mapper;
        }

        public void Adicionar(AmbienteViewModel ambiente)
        {
            var mapAmbiente = _mapper.Map<Ambiente>(ambiente);
            _ambienteRepositorio.Adicionar(mapAmbiente);        
        }

        public async Task<AmbienteViewModel> BuscarPorId(int id)
        {
            var result = await _ambienteRepositorio.BuscarPorId(id);
            return _mapper.Map<AmbienteViewModel>(result);
        }

        public void Excluir(int id)
        {
            var ambiente = _ambienteRepositorio.BuscarPorId(id).Result;
            _ambienteRepositorio.Excluir(ambiente);
        }

        public bool IdExiste(int id)
        {
            return _ambienteRepositorio.IdExiste(id);
        }
    }
}

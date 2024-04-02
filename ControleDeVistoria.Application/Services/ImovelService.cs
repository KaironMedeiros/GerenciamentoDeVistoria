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
    public class ImovelService : IImovelService
    {
        private IImovelRepositorio _imovelRepositorio;
        private readonly IMapper _mapper;


        public ImovelService(IImovelRepositorio imovelRepositorio, IMapper mapper)
        {
            _imovelRepositorio = imovelRepositorio;
            _mapper = mapper;
        }

        public void Adicionar(ImovelViewModel imovel)
        {
            var mapImovel = _mapper.Map<Imovel>(imovel);
            _imovelRepositorio.Adicionar(mapImovel);
            
        }

        public void Atualizar(ImovelViewModel imovel)
        {
            var mapImovel = _mapper.Map<Imovel>(imovel);
            _imovelRepositorio.Atualizar(mapImovel);
        }

        public ImovelViewModel BuscarPorId(int id)
        {
            var imovel = _imovelRepositorio.BuscarPorId(id);
            return _mapper.Map<ImovelViewModel>(imovel);
        }

        public ICollection<ImovelViewModel> BuscarPorUsuario()
        {
            var imovelUser = _imovelRepositorio.BuscarPorUsuario();
            return _mapper.Map<ICollection<ImovelViewModel>>(imovelUser);
        }

        public ICollection<ImovelViewModel> BuscarTodos()
        {
            var imovel = _imovelRepositorio.BuscarTodos();
            return _mapper.Map<ICollection<ImovelViewModel>>(imovel);
        }

        public void Excluir(int id)
        {
            var imovel = _imovelRepositorio.BuscarPorId(id);
            _imovelRepositorio.Excluir(imovel);
        }

        public bool IdExiste(int id)
        {
            return _imovelRepositorio.IdExiste(id);
        }
    }
}

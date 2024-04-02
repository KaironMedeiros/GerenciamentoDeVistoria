using AutoMapper;
using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Ambiente, AmbienteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Imovel, ImovelViewModel>();
            CreateMap<Locatario, LocatarioViewModel>();
            CreateMap<Vistoriador, VistoriadorViewModel>();
            CreateMap<Vistoria, VistoriaViewModel>();
        }
    }
}

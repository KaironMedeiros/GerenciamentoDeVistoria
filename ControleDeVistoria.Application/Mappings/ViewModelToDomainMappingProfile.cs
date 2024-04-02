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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AmbienteViewModel, Ambiente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ImovelViewModel, Imovel>();
            CreateMap<LocatarioViewModel, Locatario>();
            CreateMap<VistoriadorViewModel, Vistoriador>();
            CreateMap<VistoriaViewModel, Vistoria>();
        }
    }
}

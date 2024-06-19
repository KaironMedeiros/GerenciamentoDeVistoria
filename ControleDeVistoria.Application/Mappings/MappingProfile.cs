using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ControleDeVistoria.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Ambiente, AmbienteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>()
                .ForMember(dest => dest.EnderecoCompleto,
                    map => map.MapFrom(src => $"{src.Rua}, {src.Numero}, {src.Bairro}, {src.CEP}, {src.Cidade}, {src.UF}, {src.Complemento}"));
            CreateMap<Imovel, ImovelViewModel>();
            CreateMap<Locatario, LocatarioViewModel>()
                .ForMember(dest => dest.DadosCompleto,
                    map => map.MapFrom(src => $"{src.Nome}, CPF: {src.CPF}, Tel: {src.Telefone}, Data de entrada: {src.DataEntrada}, Data de saída: {src.DataSaida}"));
            CreateMap<Vistoriador, VistoriadorViewModel>();
            CreateMap<Vistoria, VistoriaViewModel>();

            CreateMap<AmbienteViewModel, Ambiente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ImovelViewModel, Imovel>();
            CreateMap<LocatarioViewModel, Locatario>();
            CreateMap<VistoriadorViewModel, Vistoriador>();
            CreateMap<VistoriaViewModel, Vistoria>();
           
        }

    }
}

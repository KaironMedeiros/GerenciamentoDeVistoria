using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.ViewModels
{
    public class LocatarioViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo CPF abrigatório")]
        public string CPF { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo nome abrigatório")]
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataEntrada { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataSaida { get; set; }
        public int ImovelId { get; set; }
        public ImovelViewModel? Imovel { get; set; }
        public string DadosCompleto { get; set; } = string.Empty;   
      

       
    }
}

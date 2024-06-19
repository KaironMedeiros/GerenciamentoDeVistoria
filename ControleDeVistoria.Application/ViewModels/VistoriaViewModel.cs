using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.ViewModels
{
    public class VistoriaViewModel
    {
        public int Id { get; set; }
        public string IdUser { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe a data da vistoria")]
        public DateTime? DataVistoria { get; set; }
        public int? MedidorAgua { get; set; }
        public int? MedidorEnergia { get; set; }
        [Required(ErrorMessage = "Informe o tipo da vistoria")]
        public string TipoVistoria { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o código do vistoriador")]
        public int? VistoriadorId { get; set; }
        public VistoriadorViewModel? Vistoriador { get; set; }
        public int ImovelId { get; set; }
        public ImovelViewModel? Imovel { get; set; }
        public ICollection<AmbienteViewModel>? Ambiente { get; set; }
    }
}

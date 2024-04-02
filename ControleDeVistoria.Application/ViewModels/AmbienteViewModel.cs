using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.ViewModels
{
    public class AmbienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Comodo abrigatório")]
        public string Comodo { get; set; }

        public string SituacaoEletrica { get; set; } = string.Empty;
        public bool ReparoEletrica { get; set; }
        [MaxLength(150, ErrorMessage = "Campo observação deve ter no máximo 150 caracteres")]
        public string ObsEletrica { get; set; } = string.Empty;

        public string SituacaoEsquadrias { get; set; } = string.Empty;
        public bool ReparoEsquadrias { get; set; }
        [MaxLength(150, ErrorMessage = "Campo observação deve ter no máximo 150 caracteres")]
        public string ObsEsquadrias { get; set; } = string.Empty;

        public string SituacaoHidraulica { get; set; } = string.Empty;
        public bool ReparoHidraulica { get; set; }
        [MaxLength(150, ErrorMessage = "Campo observação deve ter no máximo 150 caracteres")]
        public string ObsHidraulica { get; set; } = string.Empty;

        public string SituacaoPintura { get; set; } = string.Empty;
        public bool ReparoPintura { get; set; }
        [MaxLength(150, ErrorMessage = "Campo observação deve ter no máximo 150 caracteres")]
        public string ObsPintura { get; set; } = string.Empty;

        public string SituacaoPiso { get; set; } = string.Empty;
        public bool ReparoPiso { get; set; }
        [MaxLength(150, ErrorMessage = "Campo observação deve ter no máximo 150 caracteres")]
        public string ObsPiso { get; set; } = string.Empty;

        public string SituacaoTeto { get; set; } = string.Empty;
        public bool ReparoTeto { get; set; }
        [MaxLength(150, ErrorMessage = "Campo observação deve ter no máximo 150 caracteres")]
        public string ObsTeto { get; set; } = string.Empty;

        public int VistoriaId { get; set; }
        public Vistoria? Vistoria { get; set; }
    }
}

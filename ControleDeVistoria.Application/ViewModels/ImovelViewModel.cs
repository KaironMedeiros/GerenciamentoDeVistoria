using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.ViewModels
{
    public class ImovelViewModel
    {
        public int Id { get; set; }
        public string IdUser { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Tipo abrigatório")]
        public string TipoImovel { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo situação  abrigatório")]
        public string Situacao { get; set; } = string.Empty;
        public EnderecoViewModel? Endereco { get; set; }
        public LocatarioViewModel? Locatario { get; set; }
        public VistoriaViewModel? Vistoria { get; set; }
    }
}

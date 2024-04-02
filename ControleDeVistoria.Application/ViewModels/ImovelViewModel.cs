using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Enums;
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
        [Required(ErrorMessage = "Campo Tipo abrigatório")]
        public string IdUser { get; set; }
        public TipoImovel TipoImovel { get; set; }
        [Required(ErrorMessage = "Campo situação  abrigatório")]
        public SituacaoImovel Situacao { get; set; }
        public Endereco? Endereco { get; set; }
        public Locatario? Locatario { get; set; }
        public Vistoria? Vistoria { get; set; }
    }
}

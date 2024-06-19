using ControleDeVistoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.ViewModels
{
    public class VistoriadorViewModel
    {
        public int Id { get; set; }
        public string IdUser { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo nome abrigatório")]
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Email  abrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
        public ICollection<VistoriaViewModel>? Vistoria { get; set; }
    }
}

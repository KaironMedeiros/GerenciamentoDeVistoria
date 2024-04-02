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
        [Required(ErrorMessage = "Campo CPF  abrigatório")]
        public string CPF { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo nome  abrigatório")]
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public int ImovelId { get; set; }
        public Imovel? Imovel { get; set; }

        [NotMapped]
        public string LocatarioCompleto
        {
            get
            {
                return $"{Nome}, {CPF}, Tel: {Telefone}";
            }
        }
    }
}

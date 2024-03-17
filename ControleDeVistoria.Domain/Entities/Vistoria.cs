using ControleDeVistoria.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeVistoria.Domain.Entities
{
    public class Vistoria
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public DateTime DataVistoria { get; set; }
        public int MedidorAgua { get; set; }
        public int MedidorEnergia { get; set; }
        public TipoVistoria TipoVistoria { get; set; }
        public int VistoriadorId { get; set; }
        public Vistoriador? Vistoriador { get; set;}
        public int ImovelId { get; set; }
        public Imovel? Imovel { get; set; }
        public ICollection<Ambiente>? Ambiente { get; set; }       
    }
}

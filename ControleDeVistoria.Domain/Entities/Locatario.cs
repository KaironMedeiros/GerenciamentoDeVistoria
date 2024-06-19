using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeVistoria.Domain.Entities
{
    public class Locatario
    {
        public int Id { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public int ImovelId { get; set; }
        public Imovel? Imovel { get; set; }

        
    }
}

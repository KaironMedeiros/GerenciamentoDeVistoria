using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeVistoria.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string UF { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string? Numero { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string? Complemento { get; set; } = string.Empty;
        public int ImovelId { get; set; }
        public Imovel?  Imovel { get; set; }
    }
}

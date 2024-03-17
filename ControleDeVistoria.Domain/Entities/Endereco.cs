using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeVistoria.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo UF abrigatório")]
        public string UF { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Cidade abrigatório")]
        public string Cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Bairro abrigatório")]
        public string Bairro { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo Rua abrigatório")]
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo CEP abrigatório")]
        public string CEP { get; set; } = string.Empty;
        [MaxLength(150, ErrorMessage = "Complemento deve ter no máximo 150 caracteres")]
        public string? Complemento { get; set; } = string.Empty;
        public int ImovelId { get; set; }
        public Imovel?  Imovel { get; set; }

        [NotMapped]
        public string EnderecoCompleto
        {
            get 
            {
                return $"{Bairro}, Rua: {Rua}, N: {Numero}, {Cidade}-{UF}, CEP {CEP}";    
            }
        }
    }
}

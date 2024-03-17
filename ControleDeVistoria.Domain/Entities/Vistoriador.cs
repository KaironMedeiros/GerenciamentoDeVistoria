using System.ComponentModel.DataAnnotations;

namespace ControleDeVistoria.Domain.Entities
{
    public class Vistoriador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo nome abrigatório")]
        public string IdUser { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Email  abrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
        public ICollection<Vistoria>? Vistoria { get; set; }
    }
}

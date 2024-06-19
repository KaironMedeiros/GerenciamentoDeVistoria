using System.ComponentModel.DataAnnotations;

namespace ControleDeVistoria.Domain.Entities
{
    public class Vistoriador
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Vistoria>? Vistoria { get; set; }
    }
}

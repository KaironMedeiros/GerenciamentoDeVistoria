using ControleDeVistoria.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace ControleDeVistoria.Domain.Entities
{
    public class Imovel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Tipo abrigatório")]
        public string IdUser { get; set; }
        public TipoImovel TipoImovel { get; set; }
        [Required(ErrorMessage = "Campo situação  abrigatório")]
        public SituacaoImovel Situacao { get; set; }
        public Endereco? Endereco { get; set; }
        public Locatario? Locatario { get; set; }
        public Vistoria? Vistoria { get; set;}
    }
}

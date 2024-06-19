using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Domain.Entities
{
    public class Ambiente
    {
        public int Id { get; set; }

        public string Comodo { get; set; } = string.Empty;
        public string SituacaoEletrica { get; set; } = string.Empty;
        public bool ReparoEletrica { get; set; }
        public string ObsEletrica { get; set; } = string.Empty;
        public string SituacaoEsquadrias { get; set; } = string.Empty;
        public bool ReparoEsquadrias { get; set; }
        public string ObsEsquadrias { get; set; } = string.Empty;
        public string SituacaoHidraulica { get; set; } = string.Empty;
        public bool ReparoHidraulica { get; set; }
        public string ObsHidraulica { get; set; } = string.Empty;
        public string SituacaoPintura { get; set; } = string.Empty;
        public bool ReparoPintura { get; set; }
        public string ObsPintura { get; set; } = string.Empty;
        public string SituacaoPiso { get; set; } = string.Empty;
        public bool ReparoPiso { get; set; }
        public string ObsPiso { get; set; } = string.Empty;
        public string SituacaoTeto { get; set; } = string.Empty;
        public bool ReparoTeto { get; set; }
        public string ObsTeto { get; set; } = string.Empty;
        public int VistoriaId { get; set; }
        public Vistoria? Vistoria { get; set; }
    }
}


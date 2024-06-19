using ControleDeVistoria.Domain.Entities;
using ControleDeVistoria.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Application.ViewModels
{
    public class MensagemViewModel
    {
        public TipoMensagem Tipo { get; set; }
        public string Texto { get; set; } = string.Empty;

        public MensagemViewModel(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            Tipo = tipo;
            Texto = mensagem;
        }

        public static string Serializar(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            var mensagemModel = new MensagemViewModel(mensagem, tipo);
            return JsonConvert.SerializeObject(mensagemModel);
        }

        public static MensagemViewModel Desserializar(string mensagemString)
        {
            return JsonConvert.DeserializeObject<MensagemViewModel>(mensagemString);
        }
    }
}

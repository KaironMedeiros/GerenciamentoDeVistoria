using ControleDeVistoria.Application.Interfaces;
using ControleDeVistoria.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeVistoria.Web.Controllers
{
    
    public class LocatarioController : Controller
    {
        private readonly ILocatarioService _locatarioService;

        public LocatarioController(ILocatarioService locatarioService) 
        {
            _locatarioService = locatarioService;
        }

        public async Task<IActionResult> Index(int imovelId)
        {
            var imovel = await _locatarioService.BuscarPorIdImovel(imovelId);
            var locatario = await _locatarioService.BuscarPorFK(imovelId);
            ViewBag.imovel = imovel;
            return View(locatario);
        }

        public IActionResult CriarEditar(int? imovelId)
        {
            var result = _locatarioService.BuscarPorFK(imovelId.Value).Result;

            if (result != null)
            {
                return View(result);
            }
            return View();
        }
        
        
        [HttpPost]
        public IActionResult CriarEditar(LocatarioViewModel locatario)
        {
            if (ModelState.IsValid)
            {
                if (locatario.Id > 0)
                {
                    if (_locatarioService.IdExiste(locatario.ImovelId))
                    {
                        _locatarioService.Atualizar(locatario);
                        TempData["mensagem"] = MensagemViewModel.Serializar("Locatário atualizado com sucesso!");
                        return RedirectToAction("Index", "Imovel");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemViewModel.Serializar("Não foi possivel atualizar os dados!", Domain.Enums.TipoMensagem.Erro);
                        return RedirectToAction("Index", "Imovel");
                    }
                }
                else
                {
                    _locatarioService.Adicionar(locatario);
                    TempData["mensagem"] = MensagemViewModel.Serializar("Locatário cadastrado com sucesso!");
                    return RedirectToAction("Index", "Imovel");
                }
            }
            return View(locatario);
        }

        public IActionResult ExcluirConfirmacao(int imovelId)
        {
            if (_locatarioService.IdExiste(imovelId))
            {
                var result = _locatarioService.BuscarPorFK(imovelId).Result;
                return View(result);
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Imovel não encontrado", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int imovelId)
        {
            if (_locatarioService.IdExiste(imovelId))
            {
                _locatarioService.Excluir(imovelId);
                TempData["mensagem"] = MensagemViewModel.Serializar("Locatário excluido com sucesso!");
                return RedirectToAction("Index", "Imovel");
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Não foi possivel excluir os dados!", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Imovel");
        }
        



    }
}

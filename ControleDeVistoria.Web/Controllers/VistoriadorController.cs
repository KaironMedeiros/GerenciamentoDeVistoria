using ControleDeVistoria.Application.Interfaces;
using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Infra.Data.IdentityData.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeVistoria.Web.Controllers
{
    
    public class VistoriadorController : Controller
    {
        private readonly IVistoriadorService _vistoriadorService;
        private readonly UserManager<ControleDeVistoriaIdentityUser> _userManager;

        public VistoriadorController(IVistoriadorService vistoriadorService, UserManager<ControleDeVistoriaIdentityUser> userManager )
        {
            _vistoriadorService = vistoriadorService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _vistoriadorService.BuscarTodos();
            return View(result);
        }

        public IActionResult CriarEditar(int? id)
        {
            if (id > 0)
            {
                VistoriadorViewModel vistoriadorDb = _vistoriadorService.BuscarPorId(id.Value).Result;
                ViewData["UserID"] = _userManager.GetUserId(this.User);
                return View(vistoriadorDb);
            }
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View();
        }

        [HttpPost]
        public IActionResult CriarEditar(VistoriadorViewModel vistoriador)
        {
            if (ModelState.IsValid)
            {
                if (vistoriador.Id > 0)
                {
                    if (_vistoriadorService.IdExiste(vistoriador.Id))
                    {
                        _vistoriadorService.Atualizar(vistoriador);
                        TempData["mensagem"] = MensagemViewModel.Serializar("Vistoriador atualizado com sucesso!");
                        return RedirectToAction("Index", "Vistoriador");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemViewModel.Serializar("Não foi possivel atualizar os dados!", Domain.Enums.TipoMensagem.Erro);
                        return RedirectToAction("Index", "Vistoriador");
                    }
                }
                else
                {
                    _vistoriadorService.Adicionar(vistoriador);
                    TempData["mensagem"] = MensagemViewModel.Serializar("Vistoriador cadastrado com sucesso!");
                    return RedirectToAction("Index", "Vistoriador");
                }


            }
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View(vistoriador);
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            if (_vistoriadorService.IdExiste(id))
            {
                var result = _vistoriadorService.BuscarPorId(id).Result;
                return View(result);
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Vistoriador não encontrado", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoriador");
        }

        public IActionResult Excluir(int id)
        {
            if (_vistoriadorService.IdExiste(id))
            {
                _vistoriadorService.Excluir(id);
                TempData["mensagem"] = MensagemViewModel.Serializar("Vistoriador excluído com sucesso!");
                return RedirectToAction("Index", "Vistoriador");
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Não foi possivel excluir o vistoriador!", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoriador");
        }




    }
}

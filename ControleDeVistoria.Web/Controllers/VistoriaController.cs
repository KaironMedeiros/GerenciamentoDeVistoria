using ControleDeVistoria.Application.Interfaces;
using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Infra.Data.IdentityData.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeVistoria.Web.Controllers
{
    
    public class VistoriaController : Controller
    {
        private readonly IVistoriaService _vistoriaService;
        private readonly UserManager<ControleDeVistoriaIdentityUser> _userManager;

        public VistoriaController(IVistoriaService vistoriaService, UserManager<ControleDeVistoriaIdentityUser> userManager)
        {
            _vistoriaService = vistoriaService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _vistoriaService.BuscarPorUsuario();
            return View(result);
        }

        public IActionResult CriarEditar(int? imovelId)
        {
            if (imovelId != null)
            {
                var result = _vistoriaService.BuscarPorIdImovel(imovelId.Value).Result;

                if (result != null)
                {
                    return View(result);
                }
                ViewData["UserID"] = _userManager.GetUserId(this.User);
                return View();
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Não foi possivel criar uma nova vistoria!", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Imovel");
        }

        [HttpPost]
        public IActionResult CriarEditar(VistoriaViewModel vistoria)
        {
            if (ModelState.IsValid)
            {
                
                var result = _vistoriaService.BuscarPorIdVistoriador((int)vistoria.VistoriadorId).Result;


                if (result != null)
                {
                    if (vistoria.Id > 0)
                    {
                        _vistoriaService.Atualizar(vistoria);

                        return RedirectToAction("Visualizar", new { vistoriaId = vistoria.Id });
                    }

                    _vistoriaService.Adicionar(vistoria);
                    return RedirectToAction("Visualizar", new { vistoriaId = vistoria.Id });
                }
                ModelState.AddModelError("VistoriadorId", "Código de vistoriador inválido");
                return View(vistoria);
            }
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View(vistoria);
        }

        public async Task<IActionResult> Visualizar(int vistoriaId)
        {
            if (_vistoriaService.IdExiste(vistoriaId))
            {
                var ambiente = await _vistoriaService.BuscarAmbientes(vistoriaId);
                ViewBag.Ambiente = ambiente;

                var vistoriaDb = await _vistoriaService.BuscarPorId(vistoriaId);
                return View(vistoriaDb);
            }
            return RedirectToAction("Index", "Vistoria");
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            if (_vistoriaService.IdExiste(id))
            {
                var vistoriaDb = _vistoriaService.BuscarPorId(id).Result;
                return View(vistoriaDb);
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Vistoria não encontrada", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoria");
        }

        public IActionResult Excluir(int id)
        {
            if (_vistoriaService.IdExiste(id))
            {
                _vistoriaService.Excluir(id);
                TempData["mensagem"] = MensagemViewModel.Serializar("Vistoria excluida com sucesso!");
                return RedirectToAction("Index", "Vistoria");
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Não foi possivel excluir a vistoria!", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index", "Vistoriador");
        }

    }
}

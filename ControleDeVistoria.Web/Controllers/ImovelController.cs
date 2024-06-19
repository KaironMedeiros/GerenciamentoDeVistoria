using ControleDeVistoria.Application.Interfaces;
using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Infra.Data.IdentityData.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeVistoria.Web.Controllers
{
    
    public class ImovelController : Controller
    {
        private readonly IImovelService _imovelService;
        private readonly UserManager<ControleDeVistoriaIdentityUser> _userManager; 

        public ImovelController(IImovelService imovelService, UserManager<ControleDeVistoriaIdentityUser> userManager)
        {
            _imovelService = imovelService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _imovelService.BuscarTodos();
            return View(result);
        }   

        public IActionResult CriarEditar(int? id)
        {
            if (id != null && id != 0)
            {
                ImovelViewModel imovel = _imovelService.BuscarPorId(id.Value).Result;
                ViewData["UserID"] = _userManager.GetUserId(this.User);
                return View(imovel);
            }
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View();
        }

        [HttpPost]
        public IActionResult CriarEditar(ImovelViewModel imovel)

        {
            if (ModelState.IsValid)
            {
                if (imovel.Id > 0)
                {
                    if (_imovelService.IdExiste(imovel.Id))
                    {
                        _imovelService.Atualizar(imovel);
                        TempData["mensagem"] = MensagemViewModel.Serializar("Dados atualizados com sucesso!");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemViewModel.Serializar("Não foi possivel atualizar os dados!", Domain.Enums.TipoMensagem.Erro);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    _imovelService.Adicionar(imovel);
                    TempData["mensagem"] = MensagemViewModel.Serializar("Dados cadastrados com sucesso!");
                    return RedirectToAction("Index");
                }
            }
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View(imovel); 
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            if (_imovelService.IdExiste(id))
            {
                ImovelViewModel ImovelDb = _imovelService.BuscarPorId(id).Result;
                return View(ImovelDb);
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Imovel não encontrado.", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            if (_imovelService.IdExiste(id))
            {
                _imovelService.Excluir(id);
                TempData["mensagem"] = MensagemViewModel.Serializar("Imóvel excluido com sucesso!");
                return RedirectToAction("Index");
            }
            TempData["mensagem"] = MensagemViewModel.Serializar("Houve um erro na exclusão do imóvel!", Domain.Enums.TipoMensagem.Erro);
            return RedirectToAction("Index");
        }






    }
}

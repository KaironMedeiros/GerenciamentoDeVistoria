using ControleDeVistoria.Application.Interfaces;
using ControleDeVistoria.Application.ViewModels;
using ControleDeVistoria.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeVistoria.Web.Controllers
{
    
    public class AmbienteController : Controller
    {
        private readonly IAmbienteService _ambienteService;

        public AmbienteController(IAmbienteService ambienteService)
        {
            _ambienteService = ambienteService;
        }

        public IActionResult Criar(int vistoriaId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(AmbienteViewModel ambiente)
        {
            if (ModelState.IsValid)
            {
                _ambienteService.Adicionar(ambiente);
                return RedirectToAction("Visualizar", "Vistoria", new { vistoriaId = ambiente.VistoriaId });
            }
            return View(ambiente);
        }

        public IActionResult Excluir(int ambienteId, int vistoId)
        {
            if (_ambienteService.IdExiste(ambienteId))
            {
                _ambienteService.Excluir(ambienteId);
            }
            return RedirectToAction("Visualizar", "Vistoria", new { vistoriaId = vistoId });
        }
    }
}

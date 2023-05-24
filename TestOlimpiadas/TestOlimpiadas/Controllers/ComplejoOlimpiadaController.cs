using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TestOlimpiadas.Models;
using TestOlimpiadas.Repositories;
using TestOlimpiadas.Services;

namespace TestOlimpiadas.Controllers
{
    public class ComplejoOlimpiadaController : Controller
    {
        private readonly ComplejoOlimpiadaService _complejoOlimpiadaService;
        public ComplejoOlimpiadaController(ComplejoOlimpiadaService complejoOlimpiadaService)
        {
            _complejoOlimpiadaService = complejoOlimpiadaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ComplejoOlimpiadaDetail(int id) {

            var complejoOlimpiada = await _complejoOlimpiadaService.ComplejoOlimpiadaDetail(id);

            if (complejoOlimpiada == null) {
                return NotFound();
            }

            return Json(complejoOlimpiada);
        }

        public async Task<IActionResult> ComplejoOlimpiadaDetails() { 
            var complejoOlimpiadas = await _complejoOlimpiadaService.GetAllComplejoOlimpiadas();
            return Json(complejoOlimpiadas);
        }

        public IActionResult CreateComplejoOlimpiada()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreateComplejoOlimpiada(ComplejoOlimpiada complejoOlimpiada)
        {
            string message = "";
            if (ModelState.IsValid) {
                await _complejoOlimpiadaService.AddComplejoOlimpiada(complejoOlimpiada);
                message="Complejo Olimpiada correctamente agregado";
            }
            return Json(message);
        }

        [ActionName("Edit")]
        public IActionResult EditComplejoOlimpiada(int id)
        {
            ViewBag.EditComplejoOlimpiadaid = id;
            return View("EditComplejoOlimpiada");
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditComplejoOlimpiada(ComplejoOlimpiada complejoOlimpiada) {
            if (complejoOlimpiada.Id == 0)
            {
                return NotFound();
            }

            string message = "";

            if (ModelState.IsValid)
            {
         
                try
                {
                    await _complejoOlimpiadaService.UpdateComplejoOlimpiada(complejoOlimpiada);
                    message = "Complejo Olimpiada correctamente modificado";
                }
                catch (Exception ex)
                {
                    message = ex.ToString();                 
                }             
            }

            return Json(message);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteComplejoOlimpiada(string id)
        {
            int value = int.Parse(id);
            await _complejoOlimpiadaService.DeleteComplejoOlimpiada(value);
            return Json("Complejo Olimpiada correctamente Eliminado");
        }
    }
}

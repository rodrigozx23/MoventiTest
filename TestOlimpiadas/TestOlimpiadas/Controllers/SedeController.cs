using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestOlimpiadas.Models;
using TestOlimpiadas.Repositories;
using TestOlimpiadas.Services;

namespace TestOlimpiadas.Controllers
{
    public class SedeController : Controller
    {

        private readonly SedeService _sedeService;
        public SedeController(SedeService sedeService)
        {
            _sedeService = sedeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SedeDetail(int id)
        {

            var sede = await _sedeService.SedeDetail(id);

            if (sede == null)
            {
                return NotFound();
            }

            return Json(sede);
        }

        public async Task<IActionResult> SedeDetails()
        {
            var sedes = await _sedeService.GetAllSedes();
            return Json(sedes);
        }

        public IActionResult CreateSede()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreateSede(Sede sede)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                await _sedeService.AddSede(sede);
                message="Sede correctamente agregada";
            }
            return Json(message);
        }

        [ActionName("Edit")]
        public IActionResult EditSede(int id)
        {
            ViewBag.SedeId = id;
            return View("EditSede");
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditSede(Sede sede)
        {
            if (sede.Id == 0)
            {
                return NotFound();
            }

            string message = "";

            if (ModelState.IsValid)
            {

                try
                {
                    await _sedeService.UpdateSede(sede);
                    message = "Sede correctamente modificado";
                }
                catch (Exception ex)
                {
                    message = ex.ToString();
                }
            }

            return Json(message);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteSede(string id)
        {
            int value = int.Parse(id);
            await _sedeService.DeleteSede(value);
            return Json("Sede correctamente Eliminado");
        }
    }
}

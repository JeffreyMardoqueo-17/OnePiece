using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnePieceWorld.service;
using OnePieceWorld.Helpers;
using OnePieceWorld.Models;

namespace OnePieceWorld.Controllers
{
    [Route("[controller]")]
    public class TechniqueController : Controller
    {
        private readonly ITechnique? _techniqueService;

        // Constructor que inyecta el servicio de técnicas
        public TechniqueController (ITechnique technique)
        {
            _techniqueService = technique;
        }

        // Método Index para mostrar las técnicas con paginación
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            // Obtiene la lista completa de técnicas desde el servicio
            var techniques = await _techniqueService.GetAsyncTechniques();

            // Paginación de la lista de técnicas
            var paginatedList = PaginatedList<Technique>.Create(techniques, page, pageSize);

            // Devuelve la vista con la lista paginada
            return View(paginatedList);
        }

        // Método para manejar errores y devolver la vista de error
        [Route ("api/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}

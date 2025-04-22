
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnePieceWorld.service;

namespace OnePieceWorld.Controllers
{
    [Route("[controller]")]
    public class CrewController : Controller
    {
        private readonly ICrewService _crewService;

        public CrewController (ICrewService crewService){
            _crewService = crewService;
        }


        public async Task<IActionResult> Index()
        {
            var crews = await _crewService.GetCrewsAsync();
            return View(crews);
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}
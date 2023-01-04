using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRaceRepository _raceRepository;

        public RaceController(ApplicationDbContext context, IRaceRepository raceRepository)
        {
            _context = context;
            _raceRepository = raceRepository;
        }
        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }

        public IActionResult Detail(int id)
        {//Nunca esquecer de utilizar o Include quando tiver sub categorias no modelo
            Race race = _context.Races.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
            return View(race);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }
            _raceRepository.Add(race);
            return RedirectToAction("Index");
        }

    }
}

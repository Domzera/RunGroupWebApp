using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;
using RunGroupWebApp.Repository;
using RunGroupWebApp.Services;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;

        public RaceController(ApplicationDbContext context, IRaceRepository raceRepository, IPhotoService photoService)
        {
            _context = context;
            _raceRepository = raceRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> Create(CreateRaceViewModel raceVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(raceVM.Image);

                var race = new Race
                {
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = raceVM.Address.Street,
                        City = raceVM.Address.City,
                        State = raceVM.Address.State
                    }
                };
                _raceRepository.Add(race);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(raceVM);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;

        public ClubController(ApplicationDbContext context,IClubRepository clubRepository,IPhotoService photoService)
        {
            _context=context;
            _clubRepository=clubRepository;
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }

        public IActionResult Detail(int id)
        {//Nunca esquecer de utilizar o Include quando tiver sub categorias no modelo
            Club club = _context.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
            return View(club);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel clubVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(clubVM.Image);

                var club = new Club
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street= clubVM.Address.Street,
                        City= clubVM.Address.City,
                        State= clubVM.Address.State
                    }
                };
                _clubRepository.Add(club);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(clubVM);
        }
    }
}

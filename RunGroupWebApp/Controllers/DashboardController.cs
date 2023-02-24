using Microsoft.AspNetCore.Mvc;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardrepository _dashboardrepository;

        public DashboardController(IDashboardrepository dashboardrepository)
        {
            _dashboardrepository = dashboardrepository;
        }
        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardrepository.GetAllUserRaces();
            var userClubs = await _dashboardrepository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                Races = userRaces,
                Clubs = userClubs,
            };
            return View(dashboardViewModel);
        }
    }
}

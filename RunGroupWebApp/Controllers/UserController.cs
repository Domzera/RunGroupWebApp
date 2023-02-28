﻿using Microsoft.AspNetCore.Mvc;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("Users")]
        public async Task<IActionResult> Index()
        {
            var users =await _userRepository.GetAllAsync();
            List<UserVlewModel> resul = new List <UserVlewModel>();
            foreach (var user in users)
            {
                var userViewNodel = new UserVlewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Mileage,
                };
                resul.Add(userViewNodel);
            }
            return View(resul);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Pace = user.Pace,
                Mileage = user.Mileage,
            };
            return View(userDetailViewModel);
        }
    }
}

using Day63MyProj.Models.Services;
using Day63MyProj.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Day63MyProj.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var usersViewModel = await _usersService.GetAllAsync();
            return View(usersViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userViewModel = await _usersService.GetByIdAsync(id);
            return View(userViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if(!ModelState.IsValid)
                return View(userViewModel);

            await _usersService.CreateAsync(userViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userViewModel= await _usersService.GetByIdAsync(id);
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);

            await _usersService.UpdateAsync(userViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userViewModel = await _usersService.GetByIdAsync(id);
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _usersService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

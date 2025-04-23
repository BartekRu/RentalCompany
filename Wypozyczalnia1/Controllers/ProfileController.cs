using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wypozyczalnia1.Data;
using Wypozyczalnia1.Models;
using Wypozyczalnia1.ViewModels;

namespace Wypozyczalnia1.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ProfileController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nie można załadować użytkownika z ID '{_userManager.GetUserId(User)}'.");
            }

            // Załaduj profil użytkownika
            await _context.Entry(user).Reference(u => u.Profile).LoadAsync();

            var model = new ProfileViewModel
            {
                FirstName = user.Profile?.FirstName,
                LastName = user.Profile?.LastName,
                Address = user.Profile?.Address,
                UserType = user.Profile?.UserType ?? UserType.Bronze,
                Email = user.Email
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nie można załadować użytkownika z ID '{_userManager.GetUserId(User)}'.");
            }

            // Załaduj profil użytkownika
            await _context.Entry(user).Reference(u => u.Profile).LoadAsync();

            var model = new ProfileViewModel
            {
                FirstName = user.Profile?.FirstName,
                LastName = user.Profile?.LastName,
                Address = user.Profile?.Address,
                UserType = user.Profile?.UserType ?? UserType.Bronze,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nie można załadować użytkownika z ID '{_userManager.GetUserId(User)}'.");
            }

            await _context.Entry(user).Reference(u => u.Profile).LoadAsync();

            if (user.Profile == null)
            {
                user.Profile = new UserProfile
                {
                    UserId = user.Id
                };
                _context.UserProfiles.Add(user.Profile);
            }

            user.Profile.FirstName = model.FirstName;
            user.Profile.LastName = model.LastName;
            user.Profile.Address = model.Address;

            
            user.Profile.UserType = model.UserType;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
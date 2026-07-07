using FinalProject.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public SettingsController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //=====================================================
        // GET : Settings
        //=====================================================

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            SettingsViewModel vm = new SettingsViewModel
            {
                FullName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,

                UserName = user.UserName,
                UserId = user.Id,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed
            };

            return View(vm);
        }

        //=====================================================
        // POST : Save Profile
        //=====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SettingsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            // Update Profile
            user.UserName = vm.FullName;
            user.Email = vm.Email;
            user.PhoneNumber = vm.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Refresh login cookie
                await _signInManager.RefreshSignInAsync(user);

                TempData["success"] = "Profile updated successfully.";

                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            // Reload read-only values before returning the view
            vm.UserName = user.UserName;
            vm.UserId = user.Id;
            vm.EmailConfirmed = user.EmailConfirmed;
            vm.PhoneNumberConfirmed = user.PhoneNumberConfirmed;

            return View(vm);
        }
    }
}
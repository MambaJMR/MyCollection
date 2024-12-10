using ItransitionMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ItransitionMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        UserManager<CustomUser> _userManager;

        public UsersController(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            CustomUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Block(string id)
        {
            CustomUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                //user.LockoutEnabled = true;
                //await _userManager.GetLockoutEnabledAsync(user);
                user.LockoutEnd = DateTime.Now.AddYears(5).ToUniversalTime();
                await _userManager.GetLockoutEndDateAsync(user);
                await _userManager.UpdateAsync(user);
                
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Unblock(string id)
        {
            CustomUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                //user.LockoutEnabled = true;
                //await _userManager.GetLockoutEnabledAsync(user);
                user.LockoutEnd = null;
                await _userManager.GetLockoutEndDateAsync(user);
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index");
        }

    }
}

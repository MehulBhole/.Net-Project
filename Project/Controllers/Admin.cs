using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.DTO;
using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Admin : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public Admin(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult User()
        {
            var users = _userManager.Users;

            var userDtoList = new List<User>();

            foreach (var user in users)
            {
                if (user != null)
                {
                    userDtoList.Add(new User
                    {
                        Id=user.Id,
                        Email = user.Email,
                        Name = user.Name,
                        City = user.City,
                        PhoneNumber = user.PhoneNumber,
                    });
                }
            }

            return View(userDtoList);
        }

        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            var result = await _userManager.DeleteAsync(user);

            if (user == null)
            {
                return NotFound();
            }

            return RedirectToAction("User");
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(ApplicationUser user)
        //{
        //    var result = await _userManager.DeleteAsync(user);

        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("User");
        //    }
        //    else
        //    {
        //        // Handle the case where deletion failed
        //        // You can inspect the errors in result.Errors and take appropriate action
        //        return View("Error");
        //    }
        //}
    }
}

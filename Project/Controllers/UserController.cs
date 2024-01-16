using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private MyDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(MyDbContext db, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Services() 
        {
            return View();
        }

        public async Task<IActionResult> IndexUserAsync()
        {
            var ownerData = _db.ownerdatas;
            return View(ownerData);
        }
    }
}

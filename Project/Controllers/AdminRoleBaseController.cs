using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Project.DTO;
using Project.Models;

namespace Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminRoleBaseController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public AdminRoleBaseController(RoleManager<IdentityRole> roleManager) 
        { 
             _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleStore roleStore)
        {
            var alreadyAdded = await _roleManager.RoleExistsAsync(roleStore.RoleName);
   
            if (!alreadyAdded)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleStore.RoleName));
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            var roles = _roleManager.Roles; 
            var rolesDto = new List<RoleStore>();

            foreach (var role in roles)
            {
                rolesDto.Add(new RoleStore
                {
                    RoleName = role.Name
                    
                });
            }

            return View(rolesDto);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.DTO;
using Project.Models;

namespace Project.Controllers
{
    [Authorize(Roles = "Owner")]
    public class OwnerDataController : Controller
    {
        private MyDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        private readonly UserManager<ApplicationUser> _userManager;
        public OwnerDataController(MyDbContext db, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOwnerData()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOwnerData(UploadImage image)
        {
            if (image == null)
            {
                return BadRequest();
            }
            string filename = Upload(image);
            var user = await _userManager.GetUserAsync(User); // Get the current user

            var ownerData = new OwnerData()
            {
                Id = image.Id,
                Name = image.Name,
                PhoneNo = image.PhoneNo,
                PanNumber = image.PanNumber,
                DateOfBirth  = image.DateOfBirth,
                City = image.City,
                PinCode = image.PinCode,
                ImageFilePath = filename,
                OriginalUserId = user.Id

            };
            _db.Add(ownerData);
            _db.SaveChanges();
            return RedirectToAction("IndexOwner");
        }
        private string Upload(UploadImage image)
        {
            string filename = null;
            if (image.ImageFilePath != null)
            {
                //It is setting up the directory
                string uploaddir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                //To Generate UniqueImage Name
                filename = Guid.NewGuid().ToString() + "-" + image.ImageFilePath.FileName;

                string filepath = Path.Combine(uploaddir, filename);

                using (var filestream = new FileStream(filepath, FileMode.Create))  //It will create your empty image file as per the given path
                {
                    image.ImageFilePath.CopyTo(filestream);   //This will copy the stream/data of image to be uploaded to empty created file
                }

            }
            return filename;
        }
        public async Task<IActionResult> IndexOwnerAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            var ownerDataList = _db.ownerdatas.Where(data => data.OriginalUserId == user.Id).ToList();
            //var ownerDto = new 
            //     var userDto = new List<User>();

            //foreach (var user in users)
            //{
            //    userDto.Add(new User
            //    {
            //        Email = user.Email,
            //        Password=user.PasswordHash

            //    });
            //}
            return View(ownerDataList);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            OwnerData ownerproperty = _db.ownerdatas.Find(Id);
            return View(ownerproperty);

        }
        [HttpPost]
        public IActionResult Delete(OwnerData owner)
        {
            //OwnerData ownerproperty = _db.ownerdatas.Find(Id);
            _db.ownerdatas.Remove(owner);
            _db.SaveChanges();
            return RedirectToAction("IndexOwner");
        }

    }
}

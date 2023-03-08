using Medifine.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medifine.Controllers
{
    public class UserDataController : Controller
    {
        private readonly MedifineContext _context;
        public UserDataController(MedifineContext medifineContext)
        {
            _context = medifineContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(int value)
        {
            if (value == 1)
            {
                ViewBag.Message = "* Your Username is already taken. Please try again";
            }
            return View();
        }

        public IActionResult ahsfabsfhd(int value)
        {
            if (value == 1)
            {
                ViewBag.Message = "* Your Username is already taken. Please try again";
            }
            return View();
        }


        [HttpPost]
        public IActionResult Register(UserData userData)
        {
            var data = _context.UserDatas;
            ViewBag.item = data;

            int v = 0;
            foreach (var i in ViewBag.item)
            {
                if (userData.UserName == i.UserName)
                {
                    v++;
                }
            }

            if (v == 0)
            {
                UserData userdatas = new UserData()
                {
                    Id = userData.Id,
                    Email = userData.Email,
                    UserName = userData.UserName,
                    Password = userData.Password,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName
                };

                _context.UserDatas.Add(userdatas);
                _context.SaveChanges();
                return RedirectToAction("Register");
            }
            else
            {
                return RedirectToAction("Register", new { value = 1 });
            }
        }

        public IActionResult Login(int value)
        {
            if (value == 1)
            {
                ViewBag.Message = "* Invalid Username or Password";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserData userData)
        {
            var data = _context.UserDatas;
            ViewBag.item = data;

            int v = 0;
            foreach (var i in ViewBag.item)
            {
                if (userData.UserName == i.UserName && userData.Password == i.Password)
                {
                    v++;
                    break;
                }
            }

            if (v == 0)
            {
                return RedirectToAction("Login", new { value = 1 });
            }
            else
            {
                return RedirectToAction("Register");
            }
        }
    }
}

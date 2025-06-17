using Microsoft.AspNetCore.Mvc;
using MVC.Data.Models;
using MVC.Model.DTO;
using MVC.Services;

namespace MVC.Controllers
{
    public class RegistrController : Controller
    {
        private readonly IUserServices _userService;
        public RegistrController(IUserServices userServices)
        {
            _userService = userServices;
        }

        [HttpGet]
        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(UserDTO user)
        {
            return View("Index", user);
        }
        [HttpPost]
        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult LogIn(UserDTO user)
        {
            _userService.RegisterUser(user);
            return RedirectToAction("Index", "Home");
        }
    }
}

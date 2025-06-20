﻿using Microsoft.AspNetCore.Mvc;
using MVC.Model.DTO;
using MVC.Services;

namespace MVC.Controllers
{
    public class LogInController : Controller
    {
        [HttpGet]
        [Route("{controller}/{action}")]
        public IActionResult Index(UserDTO user)
        {
            return View(user);
        }
        [HttpPost]
        [Route("{controller}/{action}")]
        public IActionResult LogIn([FromServices] IUserServices userServices, UserDTO user)
        {
            string toket = userServices.Login(user);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", user.FirstName);

            return RedirectToAction("Index", "Home");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Models;
using server.Services;

namespace server.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;
        public HomeController(IUserService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return Redirect("/Home/Index");            
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            await _service.SignIn(email, password);
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return Redirect("/Home/Index");            
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string email, string password)
        {
            await _service.AddUser(email, password);
            return Redirect("/Home/Index");            
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _service.LogOut();
            return Redirect("/Home/Index"); 
        }
    }
}

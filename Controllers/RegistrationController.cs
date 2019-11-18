using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab18_CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab18_CoffeeShop.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult DisplayUser(RegisterUser newUser)
        {
            if (ModelState.IsValid)
            {
                return View(newUser);
            }
            else
            {
                return View("AddUser");
            }
        }
    }
}
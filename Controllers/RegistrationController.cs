using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab18_CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab18_CoffeeShop.Controllers
{
    public class RegistrationController : Controller
    {
        public List<RegisterUser> savedUsers = new List<RegisterUser>();

        public IActionResult Index()
        {

            string userJson = HttpContext.Session.GetString("UserListSession");
            if (userJson != null)
            {
                List<RegisterUser> savedUsers = JsonConvert.DeserializeObject<List<RegisterUser>>(userJson);
                return View(savedUsers);
            }
            return View();
        }

        public IActionResult AddUser(RegisterUser newUser)
        {

            return View();
        }

        public List<RegisterUser> PopulateFromSession()
        {
            string userListJson = HttpContext.Session.GetString("UserListSession");
            if (userListJson != null)
            {
                savedUsers = JsonConvert.DeserializeObject<List<RegisterUser>>(userListJson);

            }

            return savedUsers;
        }

        public IActionResult DisplayUser(RegisterUser newUser)
        {
            if (ModelState.IsValid)
            {
                PopulateFromSession();
                HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(newUser));

                if (!IsUserRegistered())
                {
                    savedUsers.Add(newUser);
                    //Session to Store Registered User...
                    HttpContext.Session.SetString("UserListSession", JsonConvert.SerializeObject(savedUsers));

                    return View(newUser);
                }

                return View("AddUser");

            }
            else
            {
                return View("AddUser");
            }
        }
        public bool IsUserRegistered()
        {
            string userJson = HttpContext.Session.GetString("UserSession");
            var existingUser = JsonConvert.DeserializeObject<RegisterUser>(userJson);

            string userListJson = HttpContext.Session.GetString("UserListSession");
            savedUsers = JsonConvert.DeserializeObject<List<RegisterUser>>(userListJson);

            foreach (RegisterUser user in savedUsers)
            {
                if (user.UserName.Contains(existingUser.UserName))
                {
                    // FOR LOG IN
                    // SET THE USER SESSION("UserSession, user);
                    return true;
                }
            }

            return false;

        }
        public IActionResult Login()
        {
            HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(savedUsers));


            return View();
        }
        // Verify That user Credientials exists in the SESSION LIST!

        // string userList = HttpContext.Session.GetString("GET SESSION LIST")
        // Deserialize list???
        // check if login information matches what is in list.
        // If yes. log them in. If not, send them to the registration page..





    }
}
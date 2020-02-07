using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataPassing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DataPassing.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {

            ViewData["Name"] = "Ajay";
            ViewBag.Company = "CGI";

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "You've been logged in succesfully";
                string data = JsonConvert.SerializeObject(model);
                HttpContext.Session.SetString("User", data);

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(30);
                HttpContext.Response.Cookies.Append("Cookie", "My Cookies", options);

              return  RedirectToAction("Index", "Account");
            }
            else
            { 
                TempData["Message"] = "You've been not logged in succesfully";
            }
            ViewData["Name"] = "Ajay";
            ViewBag.Company = "CGI";

            return View();
        }

        public IActionResult Index()
        {
            string data = HttpContext.Session.GetString("User");
            LoginModel Model = JsonConvert.DeserializeObject<LoginModel>(data);
            //string message = Convert.ToString(TempData["Message"]);
            string message = Convert.ToString(TempData.Peek("Message"));

            string cookie = HttpContext.Request.Cookies["Cookie"];
            TempData.Keep("Message");
            //or
            //TempData.Keep();

            return View();
        }

        public IActionResult Data(int ID, string name, string address) 
        { 
        
            string name1 = Request.Query["name"];
            string address1= Request.Query["address"];


            return View();
        }


        public IActionResult SignUp() {

            return View();
        }

[HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            //if (string.IsNullOrEmpty(model.Name))
            //{
            //    ModelState.AddModelError("Name", "EnterName");
            //}
            //if (string.IsNullOrEmpty(model.UserName))
            //{
            //    ModelState.AddModelError("UserName", "EnterUserName");
            //}


            if (ModelState.IsValid) { 
            
            }
            return View();
        }


    }
}
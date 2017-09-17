using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Add()
        {
            var model = new UserViewModel();
            model.User = new User();
            //model.User.Id = 1;
            //model.User.Name = "Петров Иван Федорович";
            //model.User.Phone = "+7(923)100 20 30";
            //model.User.Email = "petrov.if@mail.ru";
            model.CityList = new SelectList(
                               new List<SelectListItem>
                                 {
                                    new SelectListItem { Text = "Абакан", Value = "Абакан"},
                                    new SelectListItem { Text = "Барнаул", Value = "Барнаул"},
                                    new SelectListItem { Text = "Владивосток", Value = "Владивосток"},
                             }, "Value", "Text");
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(UserViewModel userVmData)
        {
            if (ModelState.IsValid)
            {
                if (userVmData.User.saveUser() == true)
                {
                    return new OkResult();
                }
                else
                {
                    return new BadRequestResult();
                }                
            }
            else
            {
                return new BadRequestResult();
            }            
        }

        /*public IActionResult List()
        {
            return View();
        }*/
    }
}

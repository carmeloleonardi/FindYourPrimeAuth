using FindYourPrimeAuthentication.Data;
using FindYourPrimeAuthentication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindYourPrimeAuthentication.Controllers
{
    [Authorize(Roles = UserRoles.Standard)]
    [Authorize(Roles = UserRoles.Premium)]
    public class FindPrimeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(FindPrimeViewModel model)
        {
            const string viewName = "/Views/FindPrime/Index.cshtml";

            try
            {
                if (ModelState.IsValid)
                {
                    
                }
            }
            catch (Exception e)
            {
                return View(viewName);
            }
            return View(viewName);
        }
    }
}

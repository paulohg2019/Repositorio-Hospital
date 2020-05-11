using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
       
        public HomeController(ILogger<HomeController>logger,RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
            
        }

 

        public async Task<IActionResult> Index()
        {
            string[] rolesNames = { "Admin", "User", "Operator" };
          
            foreach (var namesRole in rolesNames)
            {

               await CreateRoles(namesRole);
            }


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private async Task CreateRoles(string namesRole)
        {
           
          
                var roleExist = await _roleManager.RoleExistsAsync(namesRole);
                if (!roleExist)
                {
               
                await _roleManager.CreateAsync(new IdentityRole { Name = namesRole });

                }
            
        }






    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {

            if (!ModelState.IsValid)
            {
                return View();
               
            }
            var user = await _userManager.FindByNameAsync(loginDTO.username);
            if (user == null)
            {
                ViewBag.Error = "Tài khoản này không tồn tại";
                return View();
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginDTO.password, false, false);
                if (result.Succeeded)
                {
                    ViewBag.Error = "";
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ViewBag.Error = "Tài khoản này không tồn tại";
                    return View();
                }
            }
           

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(string usernameRegister, string passwordRegister)
        {
            if(!String.IsNullOrEmpty(usernameRegister) && !String.IsNullOrEmpty(passwordRegister))
            {
                await _userManager.CreateAsync(new IdentityUser { UserName = usernameRegister, Email = usernameRegister }, passwordRegister);
                return RedirectToAction(nameof(Login));
            }
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View(nameof(Login));
        }
    }
}

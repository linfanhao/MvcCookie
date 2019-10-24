using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCookie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MvcCookie.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult MakeLogin()
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name,"Ifan"),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            
            ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,user);

            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok();
        }
    }
}

using BussinessObject.Models;
using CinemaSystemWebapp.Utils;
using DataAccess.Repository;
using DataAccess.Repository.impl;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CinemaSystemWebapp.Controllers
{
    public class HomeController : Controller
    {
        private IFilmRepository filmRepository = new FilmRepository();
        private readonly IUserRepository userRepository = new UserRepository();
        

        public IActionResult Index()
        {
            List<Film> films = filmRepository.GetFilms();
            ViewBag.Films = filmRepository.GetFilms();
            return View();
        }

        public IActionResult Search(string q)
        {
            q = q?.ToLower() ?? "";
            ViewBag.Films = filmRepository.SearchFilm(q);
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(string email, string password)
        {
            string? token = Utils.Authentication.CreateToken(email, password, TimeSpan.FromDays(1));
            if (token is null)
            {
                return RedirectToAction(nameof(Signin));
            }
            Response.Cookies.Append("token", token);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string email, string password, [FromForm(Name = "g-recaptcha-response")] string gRecatchaResponse)
        {
            if (!GRecaptcha.Verify(gRecatchaResponse))
            {
                return RedirectToAction(nameof(Signup));
            }
            User user = new()
            {
                Email = email,
                Password = password,
                Name = email,
                Role = ((int)BussinessObject.Models.User.Roles.User),
                AvatarUrl = "/assets/default.jpg"
            };
            try
            {
                userRepository.Signup(user);
            }catch(Exception ex)
            {
                return RedirectToAction(nameof(Signup));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email, [FromForm(Name = "g-recaptcha-response")] string gRecatchaResponse)
        {
            if (!GRecaptcha.Verify(gRecatchaResponse))
            {
                return RedirectToAction(nameof(ForgotPassword));
            }

            if (userRepository.FindByEmail(email) is null)
            {
                return RedirectToAction(nameof(ForgotPassword));
            }
            string? token = Authentication.CreateToken(email, TimeSpan.FromMinutes(30));
            if (token is null)
            {
                return RedirectToAction(nameof(ForgotPassword));
            }
            string generatedLink = $"{Request.Host}/Home/{nameof(ResetPassword)}?token={token}";
            SMTP.Instance.Send("Reset Password", $"Here is your reset password link: {generatedLink}", email);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ResetPassword(string token)
        {
            var user = Authentication.GetUserByToken(token);
            if (user is null)
            {
                return RedirectToAction(nameof(Signout));
            }
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string password,string confirmPassword, string token)
        {
            var user = Authentication.GetUserByToken(token);
            if (user is null)
            {
                return RedirectToAction(nameof(Signout));
            }
            try
            {
                userRepository.ResetPassword(password, confirmPassword, user);

            }catch(Exception ex)
            {
                return RedirectToAction(nameof(ResetPassword), new {token = token});
            }
            return RedirectToAction(nameof(Signout));
        }

        public IActionResult Signout()
        {
            Response.Cookies.Delete("token");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
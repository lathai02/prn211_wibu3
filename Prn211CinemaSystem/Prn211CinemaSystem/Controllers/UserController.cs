using BussinessObject.Models;
using CinemaSystemWebapp.Utils;
using DataAccess.Repository;
using DataAccess.Repository.impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CinemaSystemWebapp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository = new UserRepository();
        private readonly ITicketRepository ticketRepository = new TicketRepository();
        public IActionResult Setting()
        {
            var user = Authentication.GetUserByCookies(Request.Cookies);

            if (user is null)
                return RedirectToAction("Signin", "Home");

            return View(user);
        }
        [HttpPost]
        public IActionResult AddToCard(double money)
        {
            var user = Authentication.GetUserByCookies(Request.Cookies);
            if (user is null)
                return RedirectToAction("Signin", "Home");
            try
            {
                userRepository.AddToCard(user, money);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Signout", "Home");
            }
            return RedirectToAction(nameof(Setting));
        }
        public IActionResult Tickets()
        {
            var user = Authentication.GetUserByCookies(Request.Cookies);
            if (user is null)
                return RedirectToAction("Signin", "Home");
            using var db = new CinemaSystemContext();
            List<Ticket> list = ticketRepository.GetListTicketWithFullInformation();            
            return View(list.Where(e => e.UserId == user.Id).GroupBy(e => e.Show).ToList());
        }

        [HttpPost]
        public IActionResult ChangeInfo(string name, string email, IFormFile avatar)
        {
            var user = Authentication.GetUserByCookies(Request.Cookies);
            if (user is null)
                return RedirectToAction("Signin", "Home");
            string? newAvatar = null;
            if (avatar is not null)
            {
                var uploadPath = Path.Combine(Path.GetFullPath("wwwroot"), "assets");
                using (var stream = avatar.OpenReadStream())
                 newAvatar =   UploadFile.Upload(uploadPath, avatar.FileName, stream).FileName;
            }
            userRepository.UpdateUser(user, name, email, newAvatar);
            return RedirectToAction(nameof(Setting));
        }

        [HttpPost]
        public IActionResult ChangePassword([FromForm(Name = "old-password")] string oldPassword, [FromForm(Name = "confirm-password")] string confirmPassword, [FromForm(Name = "new-password")] string newPassword)
        {
            var user = Authentication.GetUserByCookies(Request.Cookies);
            if (user is null)
                return RedirectToAction("Signin", "Home");
            try
            {
                userRepository.ChangePassword(user, newPassword, confirmPassword, oldPassword);
            }catch(Exception ex)
            {
                return RedirectToAction("Signout", "Home");
            }
            return RedirectToAction(nameof(Setting));
        }
    }
}

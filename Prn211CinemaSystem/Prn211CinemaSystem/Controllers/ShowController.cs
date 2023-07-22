using BussinessObject.Models;

using CinemaSystemWebapp.Utils;
using DataAccess.Repository.impl;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystemWebapp.Controllers
{
    public class ShowController : Controller
    {
        IShowRepository _showRepository;
        ITicketRepository _ticketRepository;
        public ShowController()
        {
            _showRepository = new ShowRepository();
            _ticketRepository = new TicketRepository();
        }

        public IActionResult Index(int id, string? message)
        {
            ViewBag.Message = message;
            Show show = _showRepository.getShowWithFilmRoomTickets(id);
            return View(show);
        }

        [HttpPost]
        public IActionResult BuyTicket(int id, int row, int col)
        {
            var user = Authentication.GetUserByCookies(Request.Cookies);

            if (user is null)
                return RedirectToAction("Signin", "Home");

            var show = _showRepository.getShowWithRoomTickets(id);

            if (show is null || show.Room?.Rows < row || show.Room?.Cols < col)
                return RedirectToAction(nameof(Index), new { id = id, message = "Invalid show or wrong seat!" });

            if (show.Tickets.Any(e => e.Row == row && e.Col == col))
                return RedirectToAction(nameof(Index), new { id = id, message = "Sorry! Your seat has been ordered!" });

            if (show.TicketPrice > user.Balance)
                return RedirectToAction(nameof(Index), new { id = id, message = "Your balance is not enough!" });

            string GenOTP()
            {
                var rand = new Random();
                return new string(Enumerable.Range(0, 6).Select(_ => (char)rand.Next('0', '9' + 1)).ToArray());
            }


            DateTime currentTime = DateTime.Now;
            Console.WriteLine(currentTime);
            Ticket ticket = new Ticket()
            {
                UserId = user.Id,
                ShowId = id,
                Row = row,
                Col = col,
                Date = currentTime,
                Otp = GenOTP()
            };
            Console.WriteLine(ticket.Date);



            _ticketRepository.addNewTicket(ticket);

            return RedirectToAction(nameof(Index), new { id = id, message = "Buy Ticket Success!" });
        }
    }
}
using BussinessObject.Models;
using CinemaSystemWebapp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CinemaSystemWebapp.Controllers
{
    [ApiController]
    [Route("/api")]
    public class APIController : Controller
    {
        public struct LoginResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("token")]
            public string? Token { get; set; }
        }

        public struct GetShowsResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("shows")]
            public List<Show> Shows { get; set; }
        }

        public struct Show
        {
            [JsonProperty("id")]
            public int ID { get; set; }

            [JsonProperty("film")]
            public string Film { get; set; }

            [JsonProperty("start")]
            public DateTime Start { get; set; }

            [JsonProperty("end")]
            public DateTime End { get; set; }

            [JsonProperty("ticket-price")]
            public double TicketPrice { get; set; }

            [JsonProperty("room")]
            public string Room { get; set; }
        }
        public struct CheckTicketResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }


        [HttpPost("login")]
        public LoginResponse Login([FromForm] string email, [FromForm] string password)
        {
            string? token = Utils.Authentication.CreateToken(email, password, TimeSpan.FromDays(1));

            if (token is null)
            {
                return new LoginResponse()
                {
                    Success = false,
                    Message = "Invalid email or password",
                    Token = null
                };
            }

            return new LoginResponse()
            {
                Success = true,
                Message = "Login successfully",
                Token = token
            };
        }

        [HttpGet("get-shows")]
        public GetShowsResponse GetShows([FromQuery] int interval)
        {
            try
            {
                using var db = new CinemaSystemContext();
                var intervalTS = TimeSpan.FromMilliseconds(interval);
                var startTime = DateTime.Now;
                var endTime = DateTime.Now.Add(intervalTS);

                return new GetShowsResponse()
                {
                    Success = true,
                    Message = "Shows successfully retrieved",
                    Shows = db.Shows
                        .Include(s => s.Film)
                        .Include(s => s.Room)
                        .Select(s => new Show()
                        {
                            ID = s.Id,
                            Film = s.Film!.Name,
                            Start = s.Start,
                            End = s.End,
                            TicketPrice = s.TicketPrice,
                            Room = s.Room!.Name
                        })
                        .Where(s => (s.End > startTime && s.End < endTime) || (s.Start > startTime && s.Start < endTime) || (s.Start < startTime && s.End > endTime))
                        .ToList()
                };
            }
            catch (Exception ex)
            {
                return new GetShowsResponse()
                {
                    Success = false,
                    Message = ex.Message,
                    Shows = new List<Show>()
                };
            }
        }

        [HttpPost("check-ticket")]
        public CheckTicketResponse CheckTicket([FromForm] string token, [FromForm] int showId, [FromForm] string email, [FromForm] string otp)
        {
            try
            {
                var user = Authentication.GetUserByToken(token);

                if (user is null)
                {
                    return new CheckTicketResponse()
                    {
                        Success = false,
                        Message = "Invalid token"
                    };
                }

                if (user.Role == (int)BussinessObject.Models.User.Roles.User)
                {
                    return new CheckTicketResponse()
                    {
                        Success = false,
                        Message = "You don't have permission to do this"
                    };
                }

                using var db = new CinemaSystemContext();
                var ticket = db.Tickets
                    .Include(e => e.User)
                    .FirstOrDefault(e => e.User!.Email == email && e.ShowId == showId && e.Otp == otp && !e.IsUsed);

                if (ticket is null)
                {
                    return new CheckTicketResponse()
                    {
                        Success = false,
                        Message = "Invalid ticket"
                    };
                }

                ticket.IsUsed = true;
                db.SaveChanges();

                return new CheckTicketResponse()
                {
                    Success = true,
                    Message = "Ticket successfully checked"
                };
            }
            catch (Exception ex)
            {
                return new CheckTicketResponse()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}

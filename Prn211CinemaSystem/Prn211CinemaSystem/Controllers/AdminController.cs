using BussinessObject.Models;
using CinemaSystemWebapp.Utils;
using DataAccess.Repository;
using DataAccess.Repository.impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CinemaSystemWebapp.Controllers
{
    public class AdminController : Controller
    {
        IUserRepository _userRepository;
        ICategoryRepository _categoryRepository;
        IFilmRepository _filmRepository;
        IRoomRepository _roomRepository;
        IShowRepository _showRepository;
        ITicketRepository _ticketRepository;

        public AdminController()
        {
            _userRepository = new UserRepository();
            _categoryRepository = new CategoryRepository();
            _filmRepository = new FilmRepository();
            _roomRepository = new RoomRepository();
            _showRepository = new ShowRepository();
            _ticketRepository = new TicketRepository();
        }

        CinemaSystemContext dbcontext = new CinemaSystemContext();


        public User AdminUser { get; set; } = null!;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = Authentication.GetUserByCookies(context.HttpContext.Request.Cookies);

            if (user is null || user.Role != (int)BussinessObject.Models.User.Roles.Admin)
            {
                context.Result = new RedirectResult("/");
            }

            AdminUser = user!;
        }

        public IActionResult Index(string? tab)
        {
            ViewBag.Categories = _categoryRepository.getListCategory();
            ViewBag.Films = _filmRepository.GetFilms();
            ViewBag.Orders = _ticketRepository.getAllTicket();

            ViewBag.ActiveTab = tab;

            return View(AdminUser);
        }

        [HttpPost]
        public IActionResult CreateShow(int id, float price, DateTime start, int room)
        {
            var film = _filmRepository.findById(id);
            var roomObj = _roomRepository.getRoomById(room);

            if (film is null || roomObj is null)
            {
                return RedirectToAction("Index", "Film", new { id = id, message = "Invalid film or room!" });
            }

            var show = new Show
            {
                FilmId = film.Id,
                RoomId = roomObj.Id,
                Start = start,
                End = start.AddMinutes(film.Length),
                TicketPrice = price
            };

            if (_showRepository.checkvalidShow(show))
            {
                return RedirectToAction("Index", "Film", new { id = id, message = "Show time is not valid!" });
            }

            _showRepository.addShow(show);

            return RedirectToAction("Index", "Film", new { id = id, message = "Create show successful!" });
        }

        [HttpPost]
        public IActionResult Category(int? id, string name, string description, string action)
        {
            switch (action)
            {
                case "create":
                    Category categoryAdd = new BussinessObject.Models.Category() { Name = name, Desc = description };
                    _categoryRepository.addCategory(categoryAdd);
                    break;
                case "edit":
                    if (id.HasValue)
                    {
                        Category categoryUpdate = new BussinessObject.Models.Category() { Id = id.Value, Name = name, Desc = description };
                        _categoryRepository.updateCategory(categoryUpdate);
                    }
                    break;
                case "delete":
                    if (id.HasValue)
                    {
                        Category categoryRemove = new BussinessObject.Models.Category() { Id = id.Value };
                        _categoryRepository.removeCategory(categoryRemove);

                    }
                    break;
                default:
                    break;
            }
            return RedirectToAction(nameof(Index), new { tab = "category" });
        }

        [HttpPost]
        public IActionResult Film(int? id, string name, string description, List<int>? categories, [FromForm(Name = "release-date")] DateTime? releaseDate, int? length, string action, IFormFile? image)
        {
            switch (action)
            {
                case "create":
                    if (image is not null)
                    {
                        var uploadPath = Path.Combine(Path.GetFullPath("wwwroot"), "assets");
                        using (var stream = image.OpenReadStream())
                        {
                            string filepath = $"/assets/{UploadFile.Upload(uploadPath, image.FileName, stream).FileName}";

                            dbcontext.Films.Add(new BussinessObject.Models.Film()
                            {
                                Name = name,
                                Desc = description,
                                Categories = dbcontext.Categories.Where(e => categories!.Contains(e.Id)).ToList(),
                                ReleaseDate = releaseDate!.Value,
                                Length = length!.Value,
                                ImageUrl = filepath
                            });

                            dbcontext.SaveChanges();
                        }
                    }
                    break;
                case "delete":
                    if (id.HasValue)
                    {
                        Film film = new BussinessObject.Models.Film() { Id = id.Value };
                        _filmRepository.deleteFilm(film);
                    }
                    break;
                default:
                    break;
            }

            return RedirectToAction(nameof(Index), new { tab = "film" });
        }
    }
}

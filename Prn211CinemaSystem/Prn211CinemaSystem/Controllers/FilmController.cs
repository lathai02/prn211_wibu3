using BussinessObject.Models;
using DataAccess.Repository;
using DataAccess.Repository.impl;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystemWebapp.Controllers
{
    public class FilmController : Controller
    {
        IRoomRepository _roomRepository;
        IFilmRepository _filmRepository;

        public FilmController()
        {
            _roomRepository = new RoomRepository();
            _filmRepository = new FilmRepository();
        }
        public IActionResult Index(int id, string? message)
        {
            ViewBag.Message = message;
            ViewBag.Rooms = _roomRepository.getListRooms();
            Film film = _filmRepository.getFilmWithCategoriesShowsRoom(id);
            return View(film);
        }
    }
}
using BussinessObject.Models;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.impl
{
    public class FilmRepository : IFilmRepository
    {
        public void createFilm(Film film) => FilmDao.GetFilmDao.addFilm(film);
        public void deleteFilm(Film film) => FilmDao.GetFilmDao.removeFilm(film);
        public Film findById(int filmId) => FilmDao.GetFilmDao.findById(filmId);
        public List<Film> GetFilms() => FilmDao.GetFilmDao.getFilm();
        public Film getFilmWithCategoriesShowsRoom(int filmId) => FilmDao.GetFilmDao.getFilmWithCategoriesShowsRoom(filmId);
        public List<Film> SearchFilm(string q)
        {
            return FilmDao.GetFilmDao.searchFilm(q);
        }
    }
}

using BussinessObject.Models;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.impl
{
    public class ShowRepository : IShowRepository
    {
        public void addShow(Show show) => ShowDao.GetShowDao.addShow(show);
        public Boolean checkvalidShow(Show show) => ShowDao.GetShowDao.checkValidShow(show);
        public Show getShowWithFilmRoomTickets(int filmId) => ShowDao.GetShowDao.getShowWithFilmRoomTickets(filmId);
        public Show getShowWithRoomTickets(int filmId) => ShowDao.GetShowDao.getShowWithRoomTickets(filmId);
    }
}

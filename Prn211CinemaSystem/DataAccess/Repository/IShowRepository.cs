using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IShowRepository
    {
        Show getShowWithFilmRoomTickets(int filmId);
        Show getShowWithRoomTickets(int filmId);
        Boolean checkvalidShow(Show show);

        void addShow(Show show);

    }
}

using BussinessObject.Models;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ITicketRepository
    {
        List<Ticket> GetListTicketWithFullInformation();

        public List<Ticket> getAllTicket();

        public void addNewTicket(Ticket ticket) => TicketDao.GetTicketDao.addNewTicket(ticket);
    }
}

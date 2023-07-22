using BussinessObject.Models;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.impl
{
    public class TicketRepository : ITicketRepository
    {
        public List<Ticket> GetListTicketWithFullInformation()
        {
            return TicketDao.GetTicketDao.GetListTicketWitFullInfomation();
        }
        public void addNewTicket(Ticket ticket) => TicketDao.GetTicketDao.addNewTicket(ticket);

        public List<Ticket> getAllTicket() => TicketDao.GetTicketDao.getAllTicket();


    }
}

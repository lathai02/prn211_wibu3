﻿using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    internal class TicketDao
    {
        private static TicketDao instance = null;
        private static object locked = new object();
        public static TicketDao GetTicketDao
        {
            get
            {
                lock (locked)
                {
                    if (instance == null)
                    {
                        instance = new TicketDao();
                    }
                    return instance;
                }

            }
        }

        internal List<Ticket> GetListTicketWitFullInfomation()
        {
            using var db = new CinemaSystemContext();
            List<Ticket> tickets = db.Tickets.Include(e => e.Show)
                .ThenInclude(e => e.Film)
                .Include(e => e.Show)
                .ThenInclude(e => e.Room)
                .ToList();
            return tickets;

        }

        public void addNewTicket(Ticket newTicket)
        {
            try
            {
                using var context = new CinemaSystemContext();
                context.Tickets.Add(newTicket);
                Console.WriteLine(newTicket.Date);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal List<Ticket> getAllTicket()
        {
            var tickets = new List<Ticket>();
            try
            {
                using var context = new CinemaSystemContext();
                tickets = context.Tickets
                    .Include(t => t.User)
                    .Include(t => t.Show)
                    .ThenInclude(s => s.Room)
                    .Include(t => t.Show)
                    .ThenInclude(s => s.Film).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tickets;
        }
    }
}

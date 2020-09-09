using RazorVectra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorVectra.Models
{
    public class TicketsModel
    {
        public List<Ticket> Tickets { get; set; }

        public TicketsModel()
        {
            Tickets = new List<Ticket>()
            {
                new Ticket
                {
                    ID="1",
                    Title="ONE-DAY PASS",
                    Price=44.99,
                    Photo="/lib/rsz_logov2.png",
                    Quantity=0,
                },
                new Ticket
                {
                    ID="2",
                    Title="TWO-DAY PASS",
                    Price=88.99,
                     Photo="/lib/rsz_logov2.png",
                     Quantity=0,
                },
                new Ticket
                {
                    ID="3",
                    Title="FOUR-DAY PASS",
                    Price=175.99,
                     Photo="/lib/rsz_logov2.png",
                     Quantity=0,
                }
            };
        }

        public List<Ticket> GetTickets()
        {
            return Tickets;
        }

        public Ticket findTicket(string id)
        {
            return Tickets.Where(t => t.ID == id).FirstOrDefault();
        }

    }
}

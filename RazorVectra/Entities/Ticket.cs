using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorVectra.Entities
{
    public class Ticket
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public int Quantity { get; set; }
        public Ticket()
        {

        }
    }
}

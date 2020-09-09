using RazorVectra.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorVectra.Models
{
    public class ClientModel
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}

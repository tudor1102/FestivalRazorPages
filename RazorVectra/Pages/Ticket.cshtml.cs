using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnASPNETCoreRazorPagesWithRealApps.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorVectra.Entities;
using RazorVectra.Models;


namespace RazorVectra.Pages
{
    public class TicketModel : PageModel
    {
        public List<Ticket> Tickets { get; set; }
        
        public void OnGet()
        {
            TicketsModel ticketsModel = new TicketsModel();
            Tickets = ticketsModel.GetTickets();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Tickets", Tickets);
            
        }
        public void OnPost(string ID)
        {
            Tickets = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "Tickets");
            Ticket toBuy = Tickets.Where(t => t.ID == ID).FirstOrDefault();
            List<Ticket> Stored = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "Products");
            if (Stored.Exists(t=>t.ID==toBuy.ID))
            {
                int quant = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, toBuy.Title);
                quant++;
                Stored.Where(t => t.ID == toBuy.ID).FirstOrDefault().Quantity = quant;
                SessionHelper.SetObjectAsJson(HttpContext.Session, toBuy.Title, quant);
            }
            else
            {
                toBuy.Quantity++;
                SessionHelper.SetObjectAsJson(HttpContext.Session, toBuy.Title, toBuy.Quantity);
                Stored.Add(toBuy);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Products", Stored);
        }
    }
}
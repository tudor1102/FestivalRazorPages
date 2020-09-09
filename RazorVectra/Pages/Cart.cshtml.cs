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
    public class CartModel : PageModel
    {
        private readonly AppDbContext _db;
        public List<Ticket> Tickets { get; set; }
        [BindProperty]
        public ClientModel Client { get; set; }
        public double Total { get; set; }
        public int TotalTickets { get; set; }
        public CartModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Tickets = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "Products");
            foreach(Ticket t in Tickets)
            {
                Total += t.Price * t.Quantity;
            }
            foreach(Ticket t in Tickets)
            {
                TotalTickets += t.Quantity;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "TotalProducts", TotalTickets);
        }

        public IActionResult OnPostDelete(string ID)
        {
            Tickets = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "Products");
            Ticket toDelete = Tickets.Where(p => p.ID == ID).FirstOrDefault();
            Tickets.Remove(toDelete);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Products", Tickets);
            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnPost()
        {
            Client.Tickets = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "Products");
            await _db.AddAsync(Client);
            await _db.SaveChangesAsync();
            return RedirectToPage("ThankYou");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnASPNETCoreRazorPagesWithRealApps.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorVectra.Entities;

namespace RazorVectra.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Ticket> Tickets { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
            Tickets = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "Products");
            if (Tickets==null)
            { 
                Tickets = new List<Ticket>();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Products", Tickets);
            }
        }
    }
}

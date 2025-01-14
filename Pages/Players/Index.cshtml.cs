using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization; // Import necesar pentru autorizare
using Proiect_Medii.Data;
using Proiect_Medii.Models;

namespace Proiect_Medii.Players
{
    [Authorize(Roles = "Admin")] // Permite acces doar utilizatorilor cu rolul Admin
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii.Data.ApplicationDbContext _context;

        public IndexModel(Proiect_Medii.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Preia lista de jucători din baza de date
            Player = await _context.Players.ToListAsync();
        }
    }
}

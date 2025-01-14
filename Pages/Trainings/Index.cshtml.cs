using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii.Data;
using Proiect_Medii.Models;

namespace Proiect_Medii.Pages.Trainings
{

    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii.Data.ApplicationDbContext _context;

        public IndexModel(Proiect_Medii.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Training> Training { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Training = await _context.Trainings.ToListAsync();
        }
    }
}

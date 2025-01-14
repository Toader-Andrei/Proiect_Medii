using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii.Data;
using Proiect_Medii.Models;

namespace Proiect_Medii.Pages.Trainings
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii.Data.ApplicationDbContext _context;

        public DetailsModel(Proiect_Medii.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Training Training { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings.FirstOrDefaultAsync(m => m.ID == id);
            if (training == null)
            {
                return NotFound();
            }
            else
            {
                Training = training;
            }
            return Page();
        }
    }
}

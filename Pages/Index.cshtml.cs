﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Proiect_Medii.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Dashboard accesibil tuturor utilizatorilor
        }
    }
}

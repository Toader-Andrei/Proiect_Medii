using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Medii.Data;
using Proiect_Medii.Models;
using System.Security.Claims;

namespace Proiect_Medii.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validarea utilizatorului din baza de date
            var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (user != null)
            {
                // Creează identitatea utilizatorului
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                // Autentifică utilizatorul
                await HttpContext.SignInAsync("CookieAuth", principal);

                // Redirecționează către Dashboard
                return RedirectToPage("/Index");
            }

            // Mesaj de eroare pentru autentificare eșuată
            ViewData["ErrorMessage"] = "Invalid username or password.";
            return Page();
        }
    }
}

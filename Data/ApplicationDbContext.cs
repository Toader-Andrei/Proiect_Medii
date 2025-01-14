using Microsoft.EntityFrameworkCore;
using Proiect_Medii.Models;

namespace Proiect_Medii.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Match> Matches { get; set; }

        public DbSet<User> Users { get; set; }


    }
}

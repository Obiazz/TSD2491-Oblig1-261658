using Microsoft.EntityFrameworkCore;
using Oblig1_261658.Models; // Husk å bytte DittProsjekt til riktig navn

namespace Oblig1_261658.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bruker> Bruker { get; set; }
    }
}

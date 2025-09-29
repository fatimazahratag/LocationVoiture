using Microsoft.EntityFrameworkCore;
using LocationVoiture.Models;

namespace LocationVoiture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Marque> Marques { get; set; }
        public DbSet<Voiture> Voitures { get; set; }

    }
}

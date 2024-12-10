using DemoIAC.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoIAC.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Définir les tables de la base de données (DbSet)
        public DbSet<Score> Scores { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using HomeBodyACG.Models;

namespace HomeBodyACG.Data
{
    public class HomeBodyACGContext : DbContext
    {
        public HomeBodyACGContext (DbContextOptions<HomeBodyACGContext> options)
            : base(options)
        {
        }

        public DbSet<Animations> Animations { get; set; }
        
    }
}

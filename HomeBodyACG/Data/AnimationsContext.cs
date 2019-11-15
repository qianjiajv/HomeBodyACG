using Microsoft.EntityFrameworkCore;
using HomeBodyACG.Models;

namespace HomeBodyACG.Data
{
    public class AnimationsContext : DbContext
    {
        public AnimationsContext (DbContextOptions<AnimationsContext> options)
            : base(options)
        {
        }

        public DbSet<Animations> Animations { get; set; }
        
    }
}

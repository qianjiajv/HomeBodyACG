using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HomeBodyACG.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HomeBodyACGContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HomeBodyACGContext>>()))
            {
                // Look for any movies.
                if (context.Animations.Any())
                {
                    return;   // DB has been seeded
                }

                context.Animations.AddRange(
                    new HomeBodyACG.Models.Animations
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        
                    },

                    new HomeBodyACG.Models.Animations
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Laboratoire4Prog.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Laboratoire4ProgContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Laboratoire4ProgContext>>()))
            {
                // Look for any movies.
                if (context.Tetes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tetes.AddRange(
                    new Tetes
                    {
                        Descript = "Soir",
                        HeureTete = DateTime.Parse("20:11"),
                        Type = "Droit",
                        Comment = "Good"
                    },

                    new Tetes
                    {
                        Descript = "Jour",
                        HeureTete = DateTime.Parse("20:15"),
                        Type = "Gauche",
                        Comment = "Good"
                    },

                    new Tetes
                    {
                        Descript = "Soir",
                        HeureTete = DateTime.Parse("10:11"),
                        Type = "Droit",
                        Comment = "Good"
                    },

                    new Tetes
                    {
                        Descript = "Jour",
                        HeureTete = DateTime.Parse("18:57"),
                        Type = "Gauche",
                        Comment = "Good"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
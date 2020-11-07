using MegaDeskWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWebApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new MegaDeskWebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDeskWebAppContext>>()))
            {
                // Look for any movies.
                if (context.DeskQuote.Any())
                {
                    return;   // DB has been seeded
                }

                context.DeskQuote.AddRange(
                    new DeskQuote
                    {
                        FirstName = "Jersen",
                        LastName = "Meim",
                        Width = 25,
                        Depth = 13,
                        NumberOfDrawers = 3,
                        DesktopMaterial = DesktopMaterial.Oak,
                        QuoteDate = DateTime.Parse("2020-10-30"),
                        RushDays = 0,
                    },
                    new DeskQuote
                    {
                        FirstName = "Spencer",
                        LastName = "Nweke ",
                        Width = 35,
                        Depth = 33,
                        NumberOfDrawers = 5,
                        DesktopMaterial = DesktopMaterial.Laminate,
                        QuoteDate = DateTime.Parse("2020-10-29"),
                        RushDays = 3,
                    },
                    new DeskQuote
                    {
                        FirstName = "Ronan",
                        LastName = "Macedo",
                        Width = 45,
                        Depth = 23,
                        NumberOfDrawers = 3,
                        DesktopMaterial = DesktopMaterial.Pine,
                        QuoteDate = DateTime.Parse("2020-10-28"),
                        RushDays = 5,
                    }, new DeskQuote
                    {
                        FirstName = "Joseph",
                        LastName = "Itiose",
                        Width = 65,
                        Depth = 48,
                        NumberOfDrawers = 3,
                        DesktopMaterial = DesktopMaterial.Veneer,
                        QuoteDate = DateTime.Parse("2020-10-27"),
                        RushDays = 7,
                    }

                );
                context.SaveChanges();
            }
        }
    }
}

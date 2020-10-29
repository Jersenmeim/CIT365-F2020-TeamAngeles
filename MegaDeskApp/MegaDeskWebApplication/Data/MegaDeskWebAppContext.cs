using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskWebApp.Models
{
    public class MegaDeskWebAppContext : DbContext
    {
        public MegaDeskWebAppContext (DbContextOptions<MegaDeskWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWebApp.Models.DeskQuote> DeskQuote { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentApp.Models;

namespace SacramentApp.Data
{
    public class SacramentAppContext : DbContext
    {
        public SacramentAppContext (DbContextOptions<SacramentAppContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentApp.Models.Meeting> Meeting { get; set; }

        public DbSet<SacramentApp.Models.Talks> Talks { get; set; }
    }
}

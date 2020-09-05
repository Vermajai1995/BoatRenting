using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoatProject.Models;

namespace BoatProject.Data
{
    public class BoatProjectContext : DbContext
    {
        public BoatProjectContext (DbContextOptions<BoatProjectContext> options)
            : base(options)
        {
        }

        public DbSet<BoatProject.Models.Boat> Boat { get; set; }

    }
}

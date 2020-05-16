using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Laboratoire4Prog.Models
{
    public class Laboratoire4ProgContext : DbContext
    {
        public Laboratoire4ProgContext (DbContextOptions<Laboratoire4ProgContext> options)
            : base(options)
        {
        }

        public DbSet<Laboratoire4Prog.Models.Tetes> Tetes { get; set; }
    }
}

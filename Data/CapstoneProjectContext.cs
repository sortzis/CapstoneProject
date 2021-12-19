using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Models;

namespace CapstoneProject.Data
{
    public class CapstoneProjectContext : DbContext
    {
        public CapstoneProjectContext (DbContextOptions<CapstoneProjectContext> options)
            : base(options)
        {
        }

        public DbSet<CapstoneProject.Models.Album> Album { get; set; }
    }
}

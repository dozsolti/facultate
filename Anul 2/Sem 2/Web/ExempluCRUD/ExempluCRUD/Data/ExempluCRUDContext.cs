using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExempluCRUD.Models
{
    public class ExempluCRUDContext : DbContext
    {
        public ExempluCRUDContext (DbContextOptions<ExempluCRUDContext> options)
            : base(options)
        {
        }

        public DbSet<ExempluCRUD.Models.Movie> Movie { get; set; }
    }
}

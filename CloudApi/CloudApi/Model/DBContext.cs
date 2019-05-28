using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApi.Model
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
                                    : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }

        public DbSet<Family> Families { get; set; }
    }
}

using Microsoft.EntityFrameworkCore; // This Is the Package we installed to connect to Database
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjadaCompany.Model
{
    public class ApplicationDbContext : DbContext // My Class Should inherit This Class from EntityFrameworkCore
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // This is an empty constructor but options is needed to be passed as parameter for Dependecy injection
        }

        // Need to add Empolyee Model that will be added to Database
        public DbSet<Employee> Employee { get; set; }
    }
}

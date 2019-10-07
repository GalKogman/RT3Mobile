using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT3MobileServices.Models
{
    public class RTDataContext : DbContext
    {
        public RTDataContext(DbContextOptions<RTDataContext> options):base(options)
        {

        }
        public DbSet<Seat> Seats { get; set; }
    }
}

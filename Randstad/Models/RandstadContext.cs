using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Randstad.Models;

namespace Randstad.Models
{
    public class RandstadContext : DbContext
    {
        public RandstadContext(DbContextOptions<RandstadContext> options) : base(options)
        {
        }

        public DbSet<Coin> Coins { get; set; }

        public DbSet<Randstad.Models.Convert> Convert { get; set; }
    }
}

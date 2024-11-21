using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.data
{
    public class ApiVpContext(DbContextOptions<ApiVpContext> options) : DbContext(options)
    {
        public DbSet<Transport> Transports {get; set;}
        public DbSet<Flight> Flights {get; set;}
        public DbSet<Journey> Journeys {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
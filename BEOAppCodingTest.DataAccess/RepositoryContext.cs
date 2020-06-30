using BEOAppCodingTest.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BEOAppCodingTest.DataAccess
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}

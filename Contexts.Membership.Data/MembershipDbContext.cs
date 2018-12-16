using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartSAR.BC.Membership.Domain.Aggregates;

namespace Contexts.Membership.Data
{
    public class MembershipDbContext : DbContext
    {
        public MembershipDbContext(DbContextOptions<MembershipDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>()
                .HasKey("_id");
            modelBuilder.Entity<Person>()
                .Property(b => b.FirstName)
                .HasField("_firstName");
            modelBuilder.Entity<Person>()
                .Property(b => b.LastName)
                .HasField("_lastName");
        }
    }
}

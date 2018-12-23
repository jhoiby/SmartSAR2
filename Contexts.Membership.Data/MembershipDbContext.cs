using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Membership.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contexts.Membership.Data
{
    public class MembershipDbContext : DbContext
    {
        public MembershipDbContext(DbContextOptions<MembershipDbContext> options)
            : base(options)
        {
        }

        public DbSet<PersonAggregate> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonAggregate>()
                .HasKey("_id");
            modelBuilder.Entity<PersonAggregate>()
                .Property(b => b.FirstName)
                .HasField("_firstName");
            modelBuilder.Entity<PersonAggregate>()
                .Property(b => b.LastName)
                .HasField("_lastName");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technical_Task_Enozom.Models;

namespace Technical_Task_Enozom.Services
{
    public class DBtalker:DbContext
    {
        public DBtalker(DbContextOptions options): base(options)
        {

        }
       public DbSet<Country> Countries { get; set; }
       public DbSet<Holiday> Holidays { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.holidays)
                .WithOne(e => e.country)
                .IsRequired();
        }
    }
}

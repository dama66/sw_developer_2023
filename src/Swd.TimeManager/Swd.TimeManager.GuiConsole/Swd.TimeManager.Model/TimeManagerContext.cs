using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class TimeManagerContext : DbContext
    {
        public DbSet<TimeRecord> TimeRecord { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Task> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=TimeManager_Production;Trusted_Connection=True;TrustServerCertificate=True;");
           // optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TimeManager_Production;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new TaskConfig());
            modelBuilder.ApplyConfiguration(new TimeRecordConfig());

        }


    }
}

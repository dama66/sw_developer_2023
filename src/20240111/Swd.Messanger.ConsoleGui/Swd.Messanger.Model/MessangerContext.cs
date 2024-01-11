using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Swd.Messanger.Model
{
    internal class MessangerContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=Messanger;Trusted_Connection=True;TrustServerCertificate=True;");
            // optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TimeManager_Production;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MessageConfig());
            modelBuilder.ApplyConfiguration(new MessageStateConfig());
            modelBuilder.ApplyConfiguration(new MessageTypeConfig());

        }

    }
}

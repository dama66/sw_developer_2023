using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    internal class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entity)
        {
            //Primary Key definieren und nach Id sortieren
            entity.HasKey(x => x.Id).IsClustered(true);
            //Pflichtfelder und Datentyp definieren
            entity.Property(m => m.Name).IsRequired().HasColumnType("nVarchar(50)");
            entity.HasIndex(m => m.Name).HasDatabaseName("idx_projectname");
            entity.Property(m => m.CreatedBy).IsRequired().HasColumnType("nVarchar(50)");
            entity.Property(m => m.UpdatedBy).HasColumnType("nVarchar(50)");
        }
    }
}

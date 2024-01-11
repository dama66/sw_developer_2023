using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            //Primary Key definieren und nach Id sortieren
            entity.HasKey(x => x.Id).IsClustered(true);
            //Pflichtfelder und Datentyp definieren
            entity.Property(m => m.FirstName).IsRequired().HasColumnType("nVarchar(50)"); //Für erstellung der Datenbank, Datentyp definieren, ....
            entity.Property(m => m.LastName).IsRequired().HasColumnType("nVarchar(50)");
            entity.HasIndex(m => m.LastName).HasDatabaseName("idx_lastname"); //Index wird bei grossen Datenmengen in der DB verwendet und Suche, Sortierung, .... schneller zu machen
            entity.Property(m => m.DisplayName).HasComputedColumnSql("[LastName] + ' ' + [FirstName]",true); //zusammengesetzte (berechnete) Spalte
            entity.Property(m => m.Email).IsRequired().HasColumnType("nVarchar(100)");
            entity.Property(m => m.CreatedBy).IsRequired().HasColumnType("nVarchar(50)");
            entity.Property(m => m.UpdatedBy).IsRequired().HasColumnType("nVarchar(50)");
        }
    }
}

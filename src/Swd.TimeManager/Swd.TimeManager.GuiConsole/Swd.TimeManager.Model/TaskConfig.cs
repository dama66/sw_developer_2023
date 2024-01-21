using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Swd.TimeManager.Model
{
    internal class TaskConfig : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> entity)
        {
            //Primary Key definieren und nach Id sortieren
            entity.HasKey(x => x.Id).IsClustered(true);
            //Pflichtfelder und Datentyp definieren

            entity.Property(m => m.Name).IsRequired().HasColumnType("nVarchar(50)");
            entity.HasIndex(m => m.Name).HasDatabaseName("idx_taskname");
            entity.Property(m => m.CreatedBy).IsRequired().HasColumnType("nVarchar(50)");
            entity.Property(m => m.UpdatedBy).HasColumnType("nVarchar(50)");
        }
    }

}

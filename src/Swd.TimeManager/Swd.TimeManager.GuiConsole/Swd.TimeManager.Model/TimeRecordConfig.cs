using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Swd.TimeManager.Model
{
    internal class TimeRecordConfig : IEntityTypeConfiguration<TimeRecord>
    {
        public void Configure(EntityTypeBuilder<TimeRecord> entity)
        {
            //Primary Key definieren und nach Id sortieren
            entity.HasKey(x => x.Id).IsClustered(true);
            //Pflichtfelder und Datentyp definieren

            entity.Property(m => m.Date).IsRequired().HasColumnType("nVarchar(50)");
            entity.HasIndex(m => m.Date).HasDatabaseName("idx_taskname");
            entity.Property(m => m.CreatedBy).IsRequired().HasColumnType("nVarchar(50)");
            entity.Property(m => m.UpdatedBy).IsRequired().HasColumnType("nVarchar(50)");
        }
    }

}

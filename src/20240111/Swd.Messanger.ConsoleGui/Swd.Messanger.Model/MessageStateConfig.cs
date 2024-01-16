using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Messanger.Model
{
    internal class MessageStateConfig : IEntityTypeConfiguration<MessageState>
    {


        public void Configure(EntityTypeBuilder<MessageState> entity)
        {
            
            //Primary Key definieren und nach Id sortieren
            entity.HasKey(x => x.Id).IsClustered(true);
            //entity.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            //Pflichtfelder und Datentyp definieren
            entity.Property(m => m.State).IsRequired().HasColumnType("nVarchar(20)"); //Für erstellung der Datenbank, Datentyp definieren, ....
        }
    }
}

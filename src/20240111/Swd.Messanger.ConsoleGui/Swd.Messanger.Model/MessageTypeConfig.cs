using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Messanger.Model
{
    internal class MessageTypeConfig : IEntityTypeConfiguration<MessageType>
    {
        public void Configure(EntityTypeBuilder<MessageType> entity)
        {
            //Primary Key definieren und nach Id sortieren
            entity.HasKey(x => x.Id).IsClustered(true);
            //Pflichtfelder und Datentyp definieren
            entity.Property(m => m.Type).IsRequired().HasColumnType("nVarchar(50)"); //Für erstellung der Datenbank, Datentyp definieren, ....
        }
    }
}

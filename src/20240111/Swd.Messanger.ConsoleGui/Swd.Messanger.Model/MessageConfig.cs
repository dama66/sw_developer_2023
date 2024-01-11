using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Swd.Messanger.Model
{
    internal class MessageConfig : IEntityTypeConfiguration<Message>
    {


        public void Configure(EntityTypeBuilder<Message> entity)
        {
            //Primary Key definieren und nach Id sortieren
            entity.HasKey(x => x.Id).IsClustered(true);
            //Pflichtfelder und Datentyp definieren
            entity.Property(m => m.Priority).IsRequired().HasColumnType("int"); //Für erstellung der Datenbank, Datentyp definieren, ....
            entity.Property(m => m.Sender).IsRequired().HasColumnType("nVarchar(50)");
            entity.Property(m => m.Receiver).IsRequired().HasColumnType("nVarchar(50)");
            entity.Property(m => m.SentMessage).IsRequired().HasColumnType("nVarchar(MAX)");
        }
    }
}

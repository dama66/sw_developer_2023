using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Messanger.Model
{
    internal class MessageState
    {
       // [RegularExpression("^[1-9][0-9]*0$")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string State { get; set; }
    }
}
